using System;
using Moq;
using Xunit; 

namespace ConwaysGameOfLife.Tests
{
    public class CellShould
    {
        [Fact]
        public void WhenInitialized_BeDead()
        {
            var cell = new Cell(CellState.Dead, It.IsAny<int>(), It.IsAny<int>());

            var result = cell.IsAlive();

            Assert.False(result);
        }

        [Fact]
        public void WhenInitialized_BeAlive()
        {
            var cell = new Cell(CellState.Alive, It.IsAny<int>(), It.IsAny<int>());

            var result = cell.IsAlive();

            Assert.True(result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, -2)]
        [InlineData(2, 3)]
        public void WhenInitialized_SetLocation(int x, int y)
        {
            var cell = new Cell(It.IsAny<CellState>(), x, y);

            var result = cell.Location;
            
            Assert.Equal(new Location(x, y), result);
        }
        [Fact]
        public void WhenCellStateAndLocationAreSame_BeEqual()
        {
            var x1 = 0;
            var y1 = 1;
            var x2 = 0;
            var y2 = 1;
            var one = new Cell(CellState.Dead, x1, y1);
            var two = new Cell(CellState.Dead, x2, y2);
            var expected = true;

            var result = (one.Equals(two));

            Assert.Equal(expected, result);
        }
    }
}
