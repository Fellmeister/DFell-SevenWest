using System.Collections.Generic;
using System.Linq;

namespace SevenWest.Core
{
    public class Person : IPerson
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }

        public string GetFullName()
        {
            return $"{First} {Last}";
        }
    }

    public static class PersonQueries
    {
        public static string FindFirstNamesByAge(this IEnumerable<Person> source, int age)
        {
            var result = string.Join(',', source.Where(x => x.Age == age).Select(p => p.First));
            return string.IsNullOrEmpty(result) ? $"No results found for age {age}." : result;

        }

        public static string FindFullNameById(this IEnumerable<Person> source, int id)
        {
            var result = source.FirstOrDefault(x => x.Id == id)?.GetFullName();
            return string.IsNullOrEmpty(result) ? $"No results found for id {id}." : result; 
        }

        public static string FindGendersByAge(this IEnumerable<Person> source)
        {
            // Split for readability
            var ages = source.GroupBy(g => g.Age)
                .Where(g => g.Any());

            // Could use a foreach loop for readability
            var result = ages.Aggregate("", 
                        (current, t) => current + $"Age: {t.First().Age}, Male: {GetGenderCount(t, 'M')} Female:{GetGenderCount(t, 'F')}\n");

            return string.IsNullOrEmpty(result) ? $"No records found." : result; // This can be the only case unless ages are missing.

        }

        private static int GetGenderCount(IGrouping<int, Person> t, char gender)
        {
            return t.Where(p => p.Gender == gender).GroupBy(g => g.Gender).Count();
        }

        public static bool IsValid(this IEnumerable<Person> source)
        {
            // Rudimentary approach to validate data. Further validations could be for
            // id ranges, first/last name lengths etc
            var enumerable = source as Person[] ?? source.ToArray();

            return (!enumerable.Any(g => g.Gender != 'M' && g.Gender != 'F')) // Simplification of the current gender landscape for demo purposes only.
                && !enumerable.Any(a => a.Age < 0)
                && !enumerable.GroupBy(i => i.Id).Any(x => x.Count() > 1);
        }
    }
}
