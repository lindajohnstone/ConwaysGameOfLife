using System;
using System.Collections.Generic;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class InputParserShould
    {
        InputParser _parser;
        public InputParserShould()
        {
            _parser = new InputParser();
        }
        [Theory]
        [InlineData("0,0", 0, 0)]
        [InlineData("100,8", 100, 8)]
        public void ReturnLocation_GivenAStringOfOneLocation(string input, int x, int y) 
        {
            var expected = new Location(x, y);

            var result = _parser.ParseLocation(input);

            Assert.True(UniverseHelper.LocationsAreEqual(expected, result));
        }

        [Fact]
        public void NotReturnNewLocation_FromInvalidString()
        {
            var input = "a,4";

            Assert.Throws<ArgumentException>(() => _parser.ParseLocation(input));
        }

        [Theory]
        [InlineData("3,4", 3, 4)]
        [InlineData("4,4", 4, 4)]
        public void ReturnNewUniverse_FromString(string input, int x, int y)
        {
            var expected = new Universe(x, y);

            var result = _parser.ParseUniverse(input);

            Assert.True(UniverseHelper.UniversesAreEqual(expected, result));
        }

        [Fact]
        public void NotReturnNewUniverse_FromInvalidString()
        {
            var input = "a,4";

            Assert.Throws<ArgumentException>(() => _parser.ParseUniverse(input));
        }
    }
}