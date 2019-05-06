using System;
using Shouldly;
using Xunit;

namespace SevenWest.Test
{
    public class MethodsTest
    {
        [Fact]
        public void Test1()
        {

        }

        private string jsonString =
            @"[{ ""id"": 53, ""first"": ""Bill"", ""last"": ""Bryson"", ""age"":23, ""gender"":""M"" },
                        { ""id"": 62, ""first"": ""John"", ""last"": ""Travolta"", ""age"":54, ""gender"":""M"" },
                        { ""id"": 41, ""first"": ""Frank"", ""last"": ""Zappa"", ""age"":23, gender:""T"" },
                        { ""id"": 31, ""first"": ""Jill"", ""last"": ""Scott"", ""age"":66, gender:""Y"" },
                        { ""id"": 31, ""first"": ""Anna"", ""last"": ""Meredith"", ""age"":66, ""gender"":""Y"" },
                        { ""id"": 31, ""first"": ""Janet"", ""last"": ""Jackson"", ""age"":66, ""gender"":""F"" }]";

        // TODO Tests here 
        [Fact]
        public void ShouldBeValidJSONInput()
        {
            // Arrange
            var tmp = "test";

            // Act

            //dynamic json = JsonConvert.DeserializeObject(jsonString);
            //json.ShouldNotBeNullOrEmpty();

            // Assert
            tmp.ShouldNotBeNullOrEmpty();


        }

        [Fact]
        public void InputFieldsAreCorrect()
        {
            // Arrange
            var code = 4;

            // Act
            // Assert
            code.ShouldBeGreaterThan(3);
        }
    }
}
