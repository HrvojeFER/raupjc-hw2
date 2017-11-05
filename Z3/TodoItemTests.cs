using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z3
{
    [TestClass()]
    public class TodoItemTests
    {
        [TestMethod()]
        public void TodoItemTest()
        {
            var item = new TodoItem("eyy");
            
            Assert.AreEqual(item.Text, "eyy");
        }

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            var item = new TodoItem("eyy");

            Assert.IsTrue(item.MarkAsCompleted());
            Assert.IsFalse(item.MarkAsCompleted());
            Assert.IsTrue(item.IsCompleted);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            var item = new TodoItem("eyy");
            var item2 = new TodoItem("eyy");

            Assert.IsFalse(item.Equals(item2));
            item2 = item;
            Assert.IsTrue(item.Equals(item2));
            Assert.IsFalse(item.Equals(null));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            var item = new TodoItem("eyy");
            var item2 = new TodoItem("eyy");

            Assert.AreNotEqual(item.GetHashCode(), item2.GetHashCode());
            item = item2;
            Assert.AreEqual(item.GetHashCode(), item2.GetHashCode());
        }
    }
}