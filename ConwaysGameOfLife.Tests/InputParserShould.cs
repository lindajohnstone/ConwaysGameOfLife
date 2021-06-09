using System;
using System.Collections.Generic;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class InputParserShould
    {
        [Theory]
        [InlineData("0,0", 0, 0)]
        [InlineData("-1,-1", -1, -1)]
        [InlineData("100,8", 100, 8)]
        public void WhenUserEntersStringOfOneAliveCellLocation_ReturnsListOfLocationContainingOnlyOneValue(string userInput, int x, int y) //TODO: shorten method name
        {
            var parser = new InputParser();
            var expected = new List<Location>() {
                new Location(x, y)
            };

            var result = parser.ParseListOfLocationsFromUserInput(userInput);

            Assert.True(UniverseHelper.ListsOfLocationsAreEqual(expected, result));
        }

        [Fact]
        public void WhenUserEntersStringOfAliveCellLocations_ReturnsListOfLocationValues()
        {
            var parser = new InputParser();
            var userInput = "0,0 0,1 0,2";
            var expected = new List<Location>() {
                new Location(0,0),
                new Location(0,1),
                new Location(0,2)
            };

            var result = parser.ParseListOfLocationsFromUserInput(userInput);

            Assert.True(UniverseHelper.ListsOfLocationsAreEqual(expected, result));
        }

        [Theory]
        [InlineData("a,0", -1, 0)]
        [InlineData("p,s", -1, -1)]
        [InlineData("3,p", 3, -1)]
        public void WhenUserInputsNonNumericAsLocations_ReturnsListOfLocationValues(string userInput, int x, int y)
        {
            var parser = new InputParser();
            var expected = new List<Location>() {
                new Location(x, y)
            };
            
            var result = parser.ParseListOfLocationsFromUserInput(userInput);

            Assert.True(UniverseHelper.ListsOfLocationsAreEqual(expected, result));
        }
    }
}