using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class OutputFormatterShould
    {
        [Theory]
        [InlineData(3, 3, ". . . \n. . . \n. . . \n")]
        [InlineData(4, 3, ". . . \n. . . \n. . . \n. . . \n")]
        public void WhenGivenDimensions_FormatUniverseAllDeadCells(int gridWidth, int gridLength, string expected)
        {
            var formatter = new OutputFormatter();
            var universe = new Universe(gridWidth, gridLength);

            var result = formatter.FormatInitialUniverse(universe);
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void WhenGameStarts_WriteWelcomeMessage()
        {
            var formatter = new OutputFormatter();
            var expected = "Welcome to Game of Life!";
            
            var result = formatter.FormatWelcomeMessage();
            
            Assert.Equal(expected, result);
        }
    }
}