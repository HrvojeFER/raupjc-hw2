using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z4;
using Z1;

namespace Z4Tests
{
    [TestClass()]
    public class HomeworkLinqQueriesTests
    {
        private University[] _unis;

        private void Prepare()
        {
            _unis = new University[4];
            _unis[0] = new University("FER");
            _unis[1] = new University("TVZ");
            _unis[2] = new University("Medicina");
            _unis[3] = new University("FFZG");

            _unis[0].Students = new Student[2];
            _unis[1].Students = new Student[2];
            _unis[2].Students = new Student[2];
            _unis[3].Students = new Student[1];

            _unis[0].Students[0] = new Student("Saša Matić", "1", Gender.Male);
            _unis[0].Students[1] = new Student("Sašana Matić", "2", Gender.Female);

            _unis[1].Students[0] = new Student("Siniša Matić", "3", Gender.Male);
            _unis[1].Students[1] = new Student("Marko Macan", "4", Gender.Male);

            _unis[2].Students[0] = new Student("Siniša Matić", "3", Gender.Male);
            _unis[2].Students[1] = new Student("Kristijan Lipovac", "6", Gender.Female);
            
            _unis[3].Students[0] = new Student("Sanja", "7", Gender.Female);
        }

        [TestMethod()]
        public void Linq1Test()
        {
            int[] integers = { 1, 3, 3, 4, 2, 2, 2, 3, 3, 4, 5 };
            var strings = HomeworkLinqQueries.Linq1(integers);

            int[] checkInts = {1, 2, 3, 4, 5, 1, 3, 4, 2, 1};

            for (int i = 0; i < strings.Length; ++i)
            {
                Assert.AreEqual(strings[i], $"Broj { checkInts[i] } ponavlja se { checkInts[i + 5] }");
            }
        }

        [TestMethod()]
        public void Linq2_1Test()
        {
            Prepare();

            var unis = HomeworkLinqQueries.Linq2_1(_unis);

            Assert.IsTrue(unis.Single().Name.Equals("TVZ"));
        }

        [TestMethod()]
        public void Linq2_2Test()
        {
            Prepare();

            var unis = HomeworkLinqQueries.Linq2_2(_unis);

            Assert.IsTrue(unis.Single().Name.Equals("FFZG"));
        }

        [TestMethod()]
        public void Linq2_3Test()
        {
            Prepare();

            var unis = HomeworkLinqQueries.Linq2_3(_unis);

            Assert.IsFalse((from stud in
                           (from stud in unis
                            group stud by stud.Jmbag)
                            where stud.Count() > 1
                            select stud).Any());
        }

        [TestMethod()]
        public void Linq2_4Test()
        {
            Prepare();
            
            var unis = HomeworkLinqQueries.Linq2_4(_unis);

            Assert.IsTrue(unis.Count() == 3);
        }

        [TestMethod()]
        public void Linq2_5Test()
        {
            Prepare();
            
            Student[] unis = HomeworkLinqQueries.Linq2_5(_unis);

            Assert.IsTrue(unis.Single().Name.Equals("Siniša Matić"));
        }
    }
}