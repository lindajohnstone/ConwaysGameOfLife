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
        public void ReturnLocation_GivenAStringOfOneLocation(string userInput, int x, int y) 
        {
            var expected = new List<Location>() {
                new Location(x, y)
            };

            var result = _parser.ParseLocations(userInput);

            Assert.True(UniverseHelper.ListsOfLocationsAreEqual(expected, result));
        }

        [Fact]
        public void ReturnLocations_GivenAStringOfLocations()
        {
            var userInput = "0,0 0,1 0,2";
            var expected = new List<Location>() {
                new Location(0,0),
                new Location(0,1),
                new Location(0,2)
            };

            var result = _parser.ParseLocations(userInput);

            Assert.True(UniverseHelper.ListsOfLocationsAreEqual(expected, result));
        }

        [Theory]
        [InlineData("a,0", -1, 0)]
        [InlineData("p,s", -1, -1)]
        [InlineData("3,p", 3, -1)]
        public void WhenNonNumericAsLocations_ReturnLocations(string userInput, int x, int y)
        {
            var expected = new List<Location>() {
                new Location(x, y)
            };
            
            var result = _parser.ParseLocations(userInput);

            Assert.True(UniverseHelper.ListsOfLocationsAreEqual(expected, result));
        }

        [Fact]
        public void ReturnNewUniverse_FromString()
        {
            var userInput = "3,4";
            var expected = new Universe(3, 4);

            var result = _parser.ParseUniverse(userInput);

            Assert.True(UniverseHelper.UniversesAreEqual(expected, result));
            Assert.Equal(12, result.Cells.Count);
        }
    }
}