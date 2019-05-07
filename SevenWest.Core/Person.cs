using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SevenWest.Core
{
    public class Person
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public string FullName => this.First + ' ' + this.Last;
    }
    public static class PersonQueries
    {
        public static string FindFirstNamesByAge(this IEnumerable<Person> source, int age)
        {
            return string.Join(',', source.Where(x => x.Age == age).Select(p => p.First));
        }

        public static string FindFullNameById(this IEnumerable<Person> source, int id)
        {
             return source.FirstOrDefault(x => x.Id == id)?.FullName;
        }

        public static string FindGendersByAge(this IEnumerable<Person> source)
        {
            return null; 
        }

    }

}
