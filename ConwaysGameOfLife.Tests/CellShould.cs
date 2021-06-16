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
            
            Assert.True(UniverseHelper.LocationsAreEqual(new Location(x, y), result));
        }

        [Theory]
        [InlineData(CellState.Dead, 0, 1, CellState.Dead, 0, 1)]
        [InlineData(CellState.Alive, 0, 1, CellState.Alive, 0, 1)]
        public void GivenTwoCells_CellStateAndLocationAreEqual(CellState state1, int x1, int y1,  CellState state2, int x2, int y2) 
        {
            var one = new Cell(state1, x1, y1);
            var two = new Cell(state2, x2, y2);

            var result = UniverseHelper.CellsAreEqual(one, two);

            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(GetCellFromDataGenerator))]
        public void GivenTwoCells_CellStateAndLocation_AreEqual(CellState state1, int x1, int y1, CellState state2, int x2, int y2)
        {
            var one = new Cell(state1, x1, y1);
            var two = new Cell(state2, x2, y2);

            var result = UniverseHelper.CellsAreEqual(one, two);

            Assert.False(result);
        }

        public static IEnumerable<object[]> GetCellFromDataGenerator()
        {
            yield return new object[]
            {
                CellState.Dead, 0, 1, CellState.Dead, 0, 2
            };
            yield return new object[]
            {
                CellState.Alive, 0, 1, CellState.Dead, 0, 1
            };
            yield return new object[]
            {
                CellState.Alive, 0, 1, CellState.Dead, 0, 2
            };
        }
    }
}
