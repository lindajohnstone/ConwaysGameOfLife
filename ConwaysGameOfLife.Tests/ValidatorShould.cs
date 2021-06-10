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
        public void WhenValidParsedInput_IsUniverse()
        {
            var input = new Universe(3, 3);

            var result = _validator.IsUniverse(input);

            Assert.True(result);
        }

        [Theory]
        [InlineData(0, 3)]
        [InlineData(3, 0)]
        public void WhenValidParsedInput_IsNotUniverse(int x, int y)
        {
            var input = new Universe(x, y);

            var result = _validator.IsUniverse(input);

            Assert.False(result);
        }

        [Theory]
        [InlineData(-1, 10)]
        [InlineData(-1, -1)]
        [InlineData(3, -1)]
        public void WhenInvalidParsedInput_IsNotUniverse(int x, int y)
        {
            var input = new Universe(x, y);

            var result = _validator.IsUniverse(input);

            Assert.False(result);
        }

        [Theory]
        [InlineData(0, 0, 3, 3)]
        [InlineData(2, 1, 3, 3)]
        public void WhenValidParsedInput_IsLocation(int x, int y, int gridWidth, int gridLength)
        {
            var input = new Location(x, y);

            var result = _validator.IsLocation(input, gridWidth, gridLength);

            Assert.True(result);
        }

        [Theory]
        [InlineData(3, 0, 3, 3)]
        [InlineData(2, 4, 3, 3)]
        public void WhenValidParsedInput_IsNotLocation(int x, int y, int gridWidth, int gridLength)
        {
            var input = new Location(x, y);

            var result = _validator.IsLocation(input, gridWidth, gridLength);

            Assert.False(result);
        }
    }
}