using System;
using SevenWest.Core;

namespace SevenWest.Main
{
    class Program
    {
        static void Main()
        {
            // This is a very basic approach to output the results as per the brief. In the case
            // of multiple sources/operations using DI and a container to resolve all data generators 
            var source = Methods.GetPersons();

            Console.WriteLine(source.FindFullNameById(42));
            Console.WriteLine(source.FindFirstNamesByAge(23));
            Console.WriteLine(source.FindGendersByAge());
        }
    }
}
