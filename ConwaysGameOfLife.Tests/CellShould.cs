using System;
using Xunit; 

namespace ConwaysGameOfLife.Tests
{
    public class CellShould
    {
        [Fact]
        public void WhenInitialized_BeDead()
        {
            var cell = new Cell(CellState.Dead);
            var result = cell.IsAlive();
            Assert.False(result);
        }

        [Fact]
        public void WhenInitialized_BeAlive()
        {
            var cell = new Cell(CellState.Alive);
            var result = cell.IsAlive();
            Assert.True(result);
        }

        [Fact]
        public void WhenInitialized_SetLocation()
        {
            var cell = new Cell(CellState.Alive);
            var x = 0;
            var y = 0;
            var result = cell.SetLocation(x, y);
            Assert.Equal(new Location(0, 0), result);
        }

        
    }
}
