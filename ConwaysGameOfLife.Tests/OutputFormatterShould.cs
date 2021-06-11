using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class OutputFormatterShould
    {
        [Theory]
        [InlineData(3, 3, ". . . \n. . . \n. . . \n")]
        [InlineData(4, 3, ". . . . \n. . . . \n. . . . \n")]
        public void WhenGivenDimensions_FormatUniverseAllDeadCells(int gridWidth, int gridLength, string expected)
        {
            var universe = new Universe(gridWidth, gridLength);

            var result = OutputFormatter.FormatUniverse(universe);
            
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("XXX", "XXX", "XXX", ". . . \n. . . \n. . . \n")]
        [InlineData("XXX", "OXX", "XXX", ". . . \n* . . \n. . . \n")]
        [InlineData("OXX", "OXX", "OXX", "* . . \n* . . \n* . . \n")]
        [InlineData("XXXO", "XXXX", "XXXX", ". . . * \n. . . . \n. . . . \n")]
        public void WhenGivenDimensions_FormatUniverse(string row1, string row2, string row3, string expected)
        {
            var initData =  row1 + Environment.NewLine +
                            row2 + Environment.NewLine +
                            row3;
            var universe = UniverseHelper.InitializeUniverse(initData);

            var result = OutputFormatter.FormatUniverse(universe);

            Assert.Equal(expected, result);
        }
    }
}