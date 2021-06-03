using System;
using System.Collections.Generic;
using System.Linq;
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

        [Theory]
        [InlineData(CellState.Dead, 0, 1, CellState.Dead, 0, 1, true)]
        [InlineData(CellState.Dead, 0, 1, CellState.Alive, 0, 1, false)]
        public void WhenCellStateAndLocationAreSame_BeEqual(CellState state1, int x1, int y1,  CellState state2, int x2, int y2, bool expected) // TODO: rename method
        {
            var one = new Cell(state1, x1, y1);
            var two = new Cell(state2, x2, y2);

            var result = UniverseHelper.CellsAreEqual(one, two);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void WhenTwoListsOfCellsSameOrderInstantiated_BeEqual()
        {
            var expected = new List<Cell>(){
                new Cell(CellState.Dead, 0, 0),
                new Cell(CellState.Dead, 0, 1),
                new Cell(CellState.Dead, 0, 2),
                new Cell(CellState.Dead, 1, 0),
                new Cell(CellState.Dead, 1, 1),
                new Cell(CellState.Dead, 1, 2),
                new Cell(CellState.Dead, 2, 0),
                new Cell(CellState.Dead, 2, 1),
                new Cell(CellState.Dead, 2, 2)
            };

            var result = new List<Cell>(){
                new Cell(CellState.Dead, 0, 0),
                new Cell(CellState.Dead, 0, 1),
                new Cell(CellState.Dead, 0, 2),
                new Cell(CellState.Dead, 1, 0),
                new Cell(CellState.Dead, 1, 1),
                new Cell(CellState.Dead, 1, 2),
                new Cell(CellState.Dead, 2, 0),
                new Cell(CellState.Dead, 2, 1),
                new Cell(CellState.Dead, 2, 2)
            };

            Assert.True(UniverseHelper.ListsOfCellsAreEqual(expected, result));
        }

        [Fact]
        public void WhenTwoListsOfCellsNotSameOrderInstantiated_BeEqual()
        {
            var expected = new List<Cell>(){
                new Cell(CellState.Dead, 0, 0),
                new Cell(CellState.Dead, 0, 1),
                new Cell(CellState.Dead, 0, 2),
                new Cell(CellState.Dead, 1, 1),
                new Cell(CellState.Dead, 1, 0),
                new Cell(CellState.Dead, 1, 2),
                new Cell(CellState.Dead, 2, 0),
                new Cell(CellState.Dead, 2, 1),
                new Cell(CellState.Dead, 2, 2)
            };

            var result = new List<Cell>(){
                new Cell(CellState.Dead, 0, 0),
                new Cell(CellState.Dead, 0, 1),
                new Cell(CellState.Dead, 0, 2),
                new Cell(CellState.Dead, 1, 0),
                new Cell(CellState.Dead, 1, 1),
                new Cell(CellState.Dead, 1, 2),
                new Cell(CellState.Dead, 2, 0),
                new Cell(CellState.Dead, 2, 1),
                new Cell(CellState.Dead, 2, 2)
            };

            Assert.True(UniverseHelper.ListsOfCellsAreEqual(expected, result)); 
        }
    }
}
