using System;
using System.Collections.Generic;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class InputParserShould
    {
        [Theory]
        [InlineData("0,0", 0, 0)]
        [InlineData("100,8", 100, 8)]
        public void ReturnLocation_GivenValidString(string input, int x, int y) 
        {
            var expected = new Location(x, y);

            var result = InputParser.ParseLocation(input);

            Assert.IsType<Location>(result);
            Assert.True(UniverseHelper.LocationsAreEqual(expected, result));
        }

        [Theory]
        [InlineData("3,4", 3, 4)]
        [InlineData("4,4", 4, 4)]
        public void ReturnUniverse_GivenValidString(string input, int x, int y)
        {
            var expected = new Universe(x, y);

            var result = InputParser.ParseUniverse(input);

            Assert.IsType<Universe>(result);
            Assert.True(UniverseHelper.UniversesAreEqual(expected, result));
        }
    }
}