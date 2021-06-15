using System;
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
        [InlineData(0, 0, 3, 3)]
        [InlineData(2, 1, 3, 3)]
        public void AcceptLocation_WhenInputIsValid(int x, int y, int gridWidth, int gridLength)
        {
            var input = new Location(x, y);

            var result = _validator.IsLocation(input, gridWidth, gridLength);

            Assert.True(result);
        }

        [Theory]
        [InlineData(3, 0, 3, 3)]
        [InlineData(3, 1, 3, 3)]
        [InlineData(0, 4, 3, 3)]
        public void NotAcceptLocation_WhenInputIsInvalid(int x, int y, int gridWidth, int gridLength)
        {
            var input = new Location(x, y);

            var result = _validator.IsLocation(input, gridWidth, gridLength);

            Assert.False(result);
        }
        //TODO: test for incorrect format e.g "0 0"
        [Fact]
        public void NotReturnNewLocation_GivenInvalidStringFormat()
        {
            var input = "4 4";

            var result = InputParser.ParseLocation(input);

            //Assert.Throws
        }

        [Fact]
        public void NotReturnNewLocation_GivenInvalidString()
        {
            var input = "a,4";

            Assert.Throws<ArgumentException>(() => InputParser.ParseLocation(input)); // TODO: Generator to ask user for new input
        }
        [Theory]
        [InlineData("a,4")]
        [InlineData("-1,3")]
        public void NotReturnNewUniverse_FromInvalidString(string input)
        {
            Assert.Throws<ArgumentException>(() => InputParser.ParseUniverse(input));
        }
    }
}