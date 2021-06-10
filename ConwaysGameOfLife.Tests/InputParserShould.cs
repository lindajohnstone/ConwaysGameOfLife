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
        [InlineData("-1,-1", -1, -1)]
        [InlineData("100,8", 100, 8)]
        [InlineData("a,0", -1, 0)]
        [InlineData("p,s", -1, -1)]
        [InlineData("3,p", 3, -1)]
        [InlineData("*,2", -1, 2)]
        public void ReturnLocation_GivenAStringOfOneLocation(string input, int x, int y) 
        {
            var expected = new Location(x, y);

            var result = _parser.ParseLocation(input);

            Assert.True(UniverseHelper.LocationsAreEqual(expected, result));
        }

        [Fact]
        public void ReturnLocations_GivenAStringOfLocations()
        {
            var input = "0,0 0,1 0,2";
            var expected = new List<Location>() {
                new Location(0,0),
                new Location(0,1),
                new Location(0,2)
            };

            var result = _parser.ParseLocations(input);

            Assert.True(UniverseHelper.ListsOfLocationsAreEqual(expected, result));
        }

        [Theory]
        [InlineData("3,4", 3, 4)]
        [InlineData("a,4", -1, 4)]
        [InlineData("10,a", 10, -1)]
        [InlineData("a,0", -1, 0)]
        [InlineData("p,s", -1, -1)]
        [InlineData("3,p", 3, -1)]
        [InlineData("*,2", -1, 2)]
        public void ReturnNewUniverse_FromString(string input, int x, int y)
        {
            var expected = new Universe(x, y);

            var result = _parser.ParseUniverse(input);

            Assert.True(UniverseHelper.UniversesAreEqual(expected, result));
        }

        [Fact]
        public void ReturnNewUniverse_FromInvalidString()
        {
            var input = "a,4";
            var expected = new Universe(-1, 4);

            var result = _parser.ParseUniverse(input);

            Assert.True(UniverseHelper.UniversesAreEqual(expected, result));
        }
    }
}