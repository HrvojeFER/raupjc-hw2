using System;
using System.Linq;
using System.Collections.Generic;

namespace Student
{
    public class MainExample
    {
        public static void Main()
        {
            var list = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 "),
                new Student (" Ivan ", jmbag :" 001234567 ")
            };

            var distinctStudentsCount = list.Distinct().Count();

            Console.WriteLine(distinctStudentsCount);
            Console.ReadKey();
        }
    }

}