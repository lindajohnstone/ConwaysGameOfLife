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

        [Theory]
        [InlineData("XXX", "XXX", "XXX", ". . . \n. . . \n. . . \n")]
        [InlineData("XXX", "OXX", "XXX", ". * . \n. . . \n. . . \n")]
        [InlineData("OXX", "OXX", "OXX", "* * * \n. . . \n. . . \n")]
        public void WhenGivenDimensionsFromUser_FormatUniverse(string col1, string col2, string col3, string expected)
        {
            var formatter = new OutputFormatter();
            var initData =  col1 + Environment.NewLine +
                            col2 + Environment.NewLine +
                            col3;
            var universe = UniverseHelper.InitializeUniverse(initData);

            var result = formatter.FormatUniverse(universe);

            Assert.Equal(expected, result);
        }
    }
}