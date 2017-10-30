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
        public void Simple_IsValid()
        {
            // arrange 
            var person = new Person();

            // act
            var isValid = person.IsValid();

            // assert
            Assert.False(isValid);
        }

        [Fact]
        public void Simple_Validate()
        {
            // arrange 
            var person = new Person();

            // act
            var errors = person.Validate();

            // assert
            Assert.True(errors.Count() > 0);
        }
    }
}