using System.Linq;
using Xunit;

namespace EntityVal.Tests
{
    public class CustomValidationTests
    {
        class EvenNumber
        {
            [CustomValidation("IsEven", "Value must be even.")]
            public int Value { get; set; }

            public bool IsEven(int i) => i % 2 == 0;
        }

        [Fact]
        public void CustomValidation_NumberIsEven()
        {
            // arrange
            var num = new EvenNumber { Value = 4 };

            // act
            var isValid = num.IsValid();

            // assert
            Assert.True(isValid);
        }

        [Fact]
        public void CustomValidation_NumberIsEven_Fail()
        {
            // arrange
            var num = new EvenNumber { Value = 5 };

            // act
            var errors = num.Validate();

            // assert
            Assert.Equal(1, errors.Count());
            Assert.Equal("Value", errors.First().FieldName);
            Assert.Equal("Value must be even.", errors.First().Message);
        }
    }
}