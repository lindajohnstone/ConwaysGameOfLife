using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class OutputFormatterShould
    {
        [Theory]
        [InlineData(3, 3, "ššš\nššš\nššš\n")]
        [InlineData(4, 3, "šššš\nšššš\nšššš\n")]
        public void WhenUniverseCreatedInitially_FormatUniverseAllDeadCells(int gridWidth, int gridLength, string expected)
        {
            var universe = new Universe(gridWidth, gridLength);

            var result = OutputFormatter.FormatUniverse(universe);
            
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("XXX", "XXX", "XXX", "ššš\nššš\nššš\n")]
        [InlineData("XXX", "OXX", "XXX", "ššš\nššš\nššš\n")]
        [InlineData("OXX", "OXX", "OXX", "ššš\nššš\nššš\n")]
        [InlineData("XXXO", "XXXX", "XXXX", "šššš\nšššš\nšššš\n")]
        public void WhenUniverseRecreated_FormatUniverse(string row1, string row2, string row3, string expected)
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