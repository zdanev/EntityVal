using System;
using System.Linq;
using Xunit;

namespace EntityVal.Tests
{
    public class Tests
    {
        class Person
        {
            [Required()]
            public string FirstName { get; set; }

            [DisplayName("Initial")]
            public string MiddleInitial { get; set; }

            public string LastName { get; set; }

            [Min(21, "Persons under 21 are not allowed.")]
            public int Age { get; set;}
        }

        [Fact]
        public void Person_IsValid()
        {
            // arrange
            var person = new Person
            {
                FirstName = "John",
                LastName = "Smith",
                Age = 40
            };

            // act
            var isValid = person.IsValid();

            // assert
            Assert.True(isValid);
        }

        [Fact]
        public void Person_IsValid_Fail()
        {
            // arrange 
            var person = new Person();

            // act
            var isValid = person.IsValid();

            // assert
            Assert.False(isValid);
        }

        [Fact]
        public void Person_Validate()
        {
            // arrange 
            var person = new Person();

            // act
            var errors = person.Validate();

            // assert
            Assert.True(errors.Count() > 0);
        }

        [Fact]
        public void MinTest()
        {
            // arrange
            var person = new Person
            {
                FirstName = "John",
                LastName = "Smith",
                Age = 20
            };

            // act
            var errors = person.Validate();

            // assert
            Assert.Equal(1, errors.Count());
            Assert.Equal("Age", errors.First().FieldName); 
            Assert.Equal("Persons under 21 are not allowed.", errors.First().Message);
        }
    }
}