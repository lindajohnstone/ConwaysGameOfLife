using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class UniverseShould
    {
        [Fact]
        public void WhenInitialized_BePopulatedWithAllDeadCells() 
        {
            var gridWidth = 4;
            var gridLength = 4;
            var universe = new Universe(gridWidth, gridLength);

            var result = universe.AreAllCellsDead();
            
            Assert.True(result);
        }  

        [Fact]
        public void WhenInitialized_UniverseSizeIsCorrect()
        {
            var gridWidth = 4;
            var gridLength = 4;
            var universe = new Universe(gridWidth, gridLength);

            var result = universe.GetSize();

            Assert.Equal(16, result);
        } 

        [Fact]
        public void WhenUniverseGenerated_ReturnsListOfNeighbours()
        {
            var universe = new Universe(3, 3);
            var cell = new Cell(CellState.Dead, 1, 1);
            var expected = new List<Location>() {
                new Location(0, 0),
                new Location(0, 1),
                new Location(0, 2),
                new Location(1, 0),
                new Location(1, 2),
                new Location(2, 0),
                new Location(2, 1),
                new Location(2, 2),
            };

            var result = universe.GetCellNeighbourLocations(cell);

            Assert.Equal(expected, result);
            Assert.Equal(8, result.Count);
        }

        [Theory]
        [InlineData(CellState.Dead, 0, 0)]
        [InlineData(CellState.Dead, 0, 1)]
        [InlineData(CellState.Dead, 0, 2)]
        [InlineData(CellState.Dead, 1, 0)]
        [InlineData(CellState.Dead, 1, 1)]
        [InlineData(CellState.Dead, 1, 2)]
        [InlineData(CellState.Dead, 2, 0)]
        [InlineData(CellState.Dead, 2, 1)]
        [InlineData(CellState.Dead, 2, 2)]
        public void WhenInitialized_FindCellStateOfCell(CellState state, int x, int y)
        {
            var universe = new Universe(3, 3);
            var location = new Location(x, y);
            var expected = state;

            var result = universe.GetCellStateFromLocation(location);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void WhenInitialized_ReturnsEmptyListOfAliveCells()
        {
            var universe = new Universe(3, 3);
            var cell = new Cell(CellState.Dead, 1, 1);
            var expected = new List<Cell>();

            var result = universe.CheckIfNeighboursAlive(cell);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void testName() // TODO: rename
        {
            var initData = "XXX" + Environment.NewLine + 
                                    "XXX" + Environment.NewLine + 
                                    "XXX";
            UniverseHelper.InitializeUniverse(initData);
            var expected = new Universe(3, 3);

            var result = UniverseHelper.InitializeUniverse(initData);

            Assert.True(UniverseHelper.UniversesAreEqual(expected, result));
        }
        [Fact]
        public void WhenUniverseRegenerated_SwitchState() // TODO: rename
        {
            var cell = new Cell(CellState.Dead, 0, 0);
            var universe = new Universe(3, 3);
            var expected = new Cell(CellState.Alive, 0, 0);

            var result = universe.SwitchCellState(cell);

            Assert.True(UniverseHelper.CellsAreEqual(expected, result));
        }

        [Fact]
        public void WhenGivenALocation_ReturnsCell()
        {
            var gridWidth = 4;
            var gridLength = 4;
            var x = 0;
            var y = 0;
            var universe = new Universe(gridWidth, gridLength);
            
            var result = universe.GetCellAtLocation(x, y);

            Assert.Equal(0, result.Location.X);
            Assert.Equal(0, result.Location.Y);
            Assert.Equal(CellState.Dead, result.CellState);
        }

        [Fact]
        public void TestUniverseHelper_UniversesAreEqual() // TODO: rename method
        {
            var gridWidth = 4;
            var gridLength = 4;
            var universe = new Universe(gridWidth, gridLength);

            var result = UniverseHelper.UniversesAreEqual(universe, new Universe(4, 4));

            Assert.True(result);
        }
    }
}