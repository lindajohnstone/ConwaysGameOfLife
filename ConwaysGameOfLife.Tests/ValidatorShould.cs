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
            var input = new Universe(3, 3);

            var result = _validator.IsUniverse(input);

            Assert.True(result);
        }

        [Fact]
        public void NotAcceptUniverse_WhenInputIsInvalid()
        {
            var input = new Universe(0, 3);

            var result = _validator.IsUniverse(input);

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
    }
}