using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class ValidatorShould
    {
        Validator _validator;
        public ValidatorShould()
        {
            _validator = new Validator();
        }

        [Fact]
        public void AcceptUniverse_WhenInputIsValid()
        {
            var input = "3,3";

            var result = _validator.IsValidUniverse(input);

            Assert.True(result);
        }

        [Theory]
        [InlineData("0,3")]
        [InlineData("4 4")]
        [InlineData(",,")]
        [InlineData("3,3,")]
        [InlineData("3,3,3")]
        [InlineData("a,b")]
        [InlineData("-1,4")]
        public void NotAcceptUniverse_WhenInputIsInvalid(string input)
        {
            var result = _validator.IsValidUniverse(input);

            Assert.False(result);
        }

        [Theory]
        [InlineData("0,0", 3, 3)]
        [InlineData("2,1", 3, 3)]
        public void AcceptLocation_WhenInputIsValid(string input, int gridWidth, int gridLength)
        {
            var result = _validator.IsValidLocation(input, gridWidth, gridLength);

            Assert.True(result);
        }

        [Theory]
        [InlineData("0,3", 3, 3)]
        [InlineData("3,0", 3, 3)]
        [InlineData("4 4", 4, 3)]
        [InlineData(",,", 3, 3)]
        [InlineData("3,3,", 4, 3)]
        [InlineData("3,3,3", 4, 3)]
        [InlineData("a,b", 3, 3)]
        [InlineData("-1,4", 3, 3)]
        [InlineData("4,-1", 3, 3)]
        public void NotAcceptLocation_WhenInputIsInvalid(string input, int gridWidth, int gridLength)
        {
            var result = _validator.IsValidLocation(input, gridWidth, gridLength);

            Assert.False(result);
        }
    }
}