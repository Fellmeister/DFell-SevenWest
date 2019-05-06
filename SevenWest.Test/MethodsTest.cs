using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Shouldly;
using Xunit;
using System.Linq;
using SevenWest.Core;

namespace SevenWest.Test
{
    public class MethodsTest
    {
        [Fact]
        public void Test1()
        {

        }

        private string jsonString =
            @"[{ 'id': 53, 'first': 'Bill', 'last': 'Bryson', 'age':23, 'gender':'M' },
                        { 'id': 62, 'first': 'John', 'last': 'Travolta', 'age':54, 'gender':'M' },
                        { 'id': 41, 'first': 'Frank', 'last': 'Zappa', 'age':23, gender:'T' },
                        { 'id': 31, 'first': 'Jill', 'last': 'Scott', 'age':66, gender:'Y' },
                        { 'id': 31, 'first': 'Anna', 'last': 'Meredith', 'age':66, 'gender':'Y' },
                        { 'id': 31, 'first': 'Janet', 'last': 'Jackson', 'age':66, 'gender':'F' }]";

        private List<Person> StubDataInput()
        {
            return JsonConvert.DeserializeObject<List<Person>>(jsonString);
        }

        // TODO Tests here 
        [Fact]
        public void ShouldBeValidGenderEntries()
        {
            // Arrange
            var inputData = StubDataInput();
            bool allGendersAreValid = !inputData.Any(x => x.Gender != 'M' || x.Gender != 'F');

            // Act


            // Assert
            allGendersAreValid.ShouldBeTrue();




        }

        [Fact]
        public void ShouldBeInputFieldsAreCorrect()
        {
            // Arrange
            var code = 4;

            // Act
            // Assert
            code.ShouldBeGreaterThan(3);
        }
    }
}
