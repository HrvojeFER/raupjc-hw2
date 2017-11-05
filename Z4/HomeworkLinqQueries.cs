using System.Linq;
using Z1;

namespace Z4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            var query = intArray.GroupBy(i => i).OrderBy(i => i.Key);

            var strings = new string[query.Count()];
            for (var i = 0; i < query.Count(); ++i)
            {
                strings[i] = $"Broj {query.ElementAt(i).Key} ponavlja se { query.ElementAt(i).Count() }";
            }

            return strings;
        }

        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(uni => uni.Students.All(y => y.Gender == Gender.Male)).ToArray();
        }

        public static University[] Linq2_2(University[] universityArray)
        {
            return (from uni in universityArray
                    where uni.Students.Count() <
                      (double)universityArray.SelectMany(i => i.Students).Count() / universityArray.Count()
                    select uni).ToArray();
        }

        public static Student[] Linq2_3(University[] universityArray)
        {
            return (from uni in universityArray
                    from stud in uni.Students
                    select stud).Distinct().ToArray();
        }

        public static Student[] Linq2_4(University[] universityArray)
        {
            return (from uni in universityArray
                    where uni.Students.All(stud => stud.Gender == Gender.Male) ||
                          uni.Students.All(stud => stud.Gender == Gender.Female)
                    from stud in uni.Students
                    select stud).Distinct().ToArray();
        }

        public static Student[] Linq2_5(University[] universityArray)
        {
            return (from stud in 
                   (from uni in universityArray
                    from stud in uni.Students
                    group stud by stud.Jmbag)
                    where stud.Count() > 1
                    select stud).SelectMany(stud => stud).Distinct().ToArray();
        }
    }
}
