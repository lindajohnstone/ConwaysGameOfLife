using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class UniverseShould
    {
        [Fact]
        public void WhenInitialized_HaveListCells()
        {
            var universe = new Universe(It.IsAny<int>(), It.IsAny<int>());
            var result = universe.Cells.GetType();
            Assert.Equal(typeof(List<Cell>), result);
        }

        [Fact]
        public void WhenInitialized_BePopulatedWithAllDeadCells() 
        {
            var gridWidth = 4;
            var gridLength = 4;
            var universe = new Universe(gridWidth, gridLength);
            var expected = 16;
            var result = universe.Cells;
            Assert.All(result, cell => Assert.False(cell.IsAlive()));
            foreach (var cell in result)
            {
                Assert.False(cell.IsAlive());
            }
            Assert.Equal(expected, result.Count);
        }

        
    }
}