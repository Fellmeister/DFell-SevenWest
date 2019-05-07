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

        [Fact]
        public void ShouldBeValidGenderEntries()
        {
            // Arrange
            var inputData = StubDataInput();
            bool allGendersAreValid = !inputData.Any(x => x.Gender != 'M' || x.Gender != 'F');

            // Act

            // Assert
            allGendersAreValid.ShouldBeFalse();
        }

        [Fact]
        public void ShouldReturnFullNameForValidID()
        {
            // Arrange
            var id = 41;
            var inputData = StubDataInput();

            // Act
            var retVal = inputData.FindFullNameById(id);

            // Assert
            retVal.ShouldNotBeNullOrEmpty();
            retVal.ShouldMatch("Frank Zappa"); 

        }

        [Fact]
        public void ShouldNotReturnFullNameForInvalidID()
        {
            // Arrange
            var id = 0;
            var inputData = StubDataInput();

            // Act
            var retVal = inputData.FindFullNameById(id);

            // Assert
            retVal.ShouldBeNullOrEmpty();

        }

        [Fact]
        public void ShouldReturnFirstNamesForGivenAge()
        {
            // Arrange
            var age = 23;
            var inputData = StubDataInput();

            // Act
            var retVal = inputData.FindFirstNamesByAge(age);

            // Assert
            retVal.ShouldNotBeNullOrEmpty();

        }

        [Fact]
        public void ShouldReturnNullForGivenAge()
        {
            // Arrange
            var age = 120;
            var inputData = StubDataInput();

            // Act
            var retVal = inputData.FindFirstNamesByAge(age);

            // Assert
            retVal.ShouldBeNullOrEmpty();

        }

    }
}
