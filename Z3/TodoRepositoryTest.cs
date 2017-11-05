using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z2;

namespace Z3
{
    [TestClass()]
    public class TodoRepositoryTest
    {
        private TodoRepository _repo = new TodoRepository();
        
        [TestMethod()]
        public void GetTest()
        {
            Assert.IsNull(_repo.Get(Guid.NewGuid()));
            
            var item = new TodoItem("ey");
            var id = item.Id;
            var item2 = new TodoItem("ahoy");
            var id2 = item2.Id;

            _repo.Add(item);
            _repo.Add(item2);
            Assert.AreEqual(_repo.Get(id), item);
            Assert.AreEqual(_repo.Get(id2), item2);
        }

        [TestMethod()]
        public void AddTest()
        {
            var item = new TodoItem("ey");
            var id = item.Id;

            Assert.AreEqual(_repo.Add(item), item);

            try
            {
                _repo.Add(item);
            }
            catch (DuplicateTodoItemException ex)
            {
                Assert.AreEqual(ex.Item, item);
            }

            Assert.AreEqual(_repo.Get(id), item);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            var item = new TodoItem("ey");
            var id = item.Id;
            _repo.Add(item);
            
            Assert.IsTrue(_repo.Remove(id));
            Assert.IsFalse(_repo.Remove(id));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var item = new TodoItem("ey");
            var id = item.Id;
            var item2 = new TodoItem("ahoy");

            Assert.AreEqual(_repo.Update(item), item);
            Assert.AreEqual(_repo.Update(item2), item2);

            item.Text = "mate";

            Assert.AreEqual(_repo.Update(item), item);
            Assert.AreEqual(_repo.Get(id).Text, "mate");
        }

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            Assert.IsFalse(_repo.MarkAsCompleted(Guid.NewGuid()));

            var item = new TodoItem("ey");
            var id = item.Id;
            var item2 = new TodoItem("ahoy");
            _repo.Add(item);
            _repo.Add(item2);

            Assert.IsTrue(_repo.MarkAsCompleted(id));
            _repo.Remove(id);
            Assert.IsFalse(_repo.MarkAsCompleted(id));
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var item = new TodoItem("ey");
            var item2 = new TodoItem("ahoy");
            item.DateCreated = DateTime.MinValue;
            item2.DateCreated = DateTime.MaxValue;
            _repo.Add(item2);
            _repo.Add(item);

            Assert.AreEqual(_repo.GetAll().ElementAt(0).DateCreated, DateTime.MinValue);
        }

        [TestMethod()]
        public void GetActiveTest()
        {
            var item = new TodoItem("ey");
            var item2 = new TodoItem("ahoy");
            item.MarkAsCompleted();
            item2.MarkAsCompleted();
            _repo.Add(item2);
            _repo.Add(item);

            Assert.IsTrue(_repo.GetActive().Count == 0);

            var item3 = new TodoItem("mate");
            _repo.Add(item3);

            Assert.IsTrue(_repo.GetActive().Count == 1);
        }

        [TestMethod()]
        public void GetCompletedTest()
        {
            var item = new TodoItem("ey");
            var item2 = new TodoItem("ahoy");
            _repo.Add(item2);
            _repo.Add(item);

            Assert.IsTrue(_repo.GetCompleted().Count == 0);

            item2.DateCompleted = DateTime.MaxValue;

            Assert.IsTrue(_repo.GetCompleted().Count == 1);
        }

        [TestMethod()]
        public void GetFilteredTest()
        {
            var item = new TodoItem("ey");
            var item2 = new TodoItem("ahoy");
            item.DateCreated = DateTime.MinValue;
            item2.DateCreated = DateTime.MaxValue;
            _repo.Add(item2);
            _repo.Add(item);
            
            Assert.IsTrue(_repo.GetFiltered(x => x.DateCreated.Equals(DateTime.MinValue)).Contains(item));
        }
    }
}