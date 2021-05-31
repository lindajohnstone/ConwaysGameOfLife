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
            var expected = new List<Location>();
            expected.Add(new Location(0, 0));
            expected.Add(new Location(0, 1));
            expected.Add(new Location(0, 2));
            expected.Add(new Location(1, 0));
            expected.Add(new Location(1, 2));
            expected.Add(new Location(2, 0));
            expected.Add(new Location(2, 1));
            expected.Add(new Location(2, 2));

            var result = universe.GetCellNeighbourLocations(cell);

            Assert.Equal(expected, result);
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
        public void WhenInitialized_ReturnsEmptyListOfAliveCells_UsingSourceData()
        {
            var universe = new Universe(SourceData.UniverseInitializedAllDeadCells());
            var cell = new Cell(CellState.Dead, 1, 1);
            var expected = new List<Cell>();

            var result = universe.CheckIfNeighboursAlive(cell);

            Assert.Equal(expected, result);
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
        public void WhenInitialized_FindCellStateOfCell_UsingSourceData(CellState state, int x, int y)
        {
            var universe = new Universe(SourceData.UniverseInitializedAllDeadCells());
            var location = new Location(x, y);
            var expected = state;

            var result = universe.GetCellStateFromLocation(location);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void testName() // test being used to test method 
        {
            var initData = "XXX" + Environment.NewLine + "XXX" + Environment.NewLine + "XXX";
            TestUniverse.InitializeUniverse(initData);
            var expected = new Universe(3, 3);

            var result = TestUniverse.InitializeUniverse(initData);

            Assert.Equal(expected, result);
        }
    }
}