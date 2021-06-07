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
        public void WhenGivenANonBoundaryCell_ReturnCorrectNeighbours()
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

            Assert.True(UniverseHelper.ListsOfLocationsAreEqual(expected, result));
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
            var expected = state;

            var result = universe.GetCellAtLocation(x, y).CellState;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("XXX", "XXX", "XXX", 1, 1, 0)]
        [InlineData("XXX", "OXX", "XXX", 1, 1, 1 )]
        [InlineData("OOO", "OOO", "OOO", 1, 1, 8)]
        [InlineData("OXX", "XXX", "XXO", 1, 1, 2)]
        public void WhenInitialized_ReturnsCountOfLiveNeighbours(string row1, string row2, string row3, int x, int y, int expected) 
        {
            var initData =  row1 + Environment.NewLine +
                            row2 + Environment.NewLine +
                            row3;
            var universe = UniverseHelper.InitializeUniverse(initData);
            var cell = universe.GetCellAtLocation(x, y);

            var result = universe.CountLiveNeighbours(cell);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void testName() // TODO: rename
        {
            var initData =  "XXX" + Environment.NewLine + 
                            "XXX" + Environment.NewLine + 
                            "XXX";
            UniverseHelper.InitializeUniverse(initData);
            var expected = new Universe(3, 3);

            var result = UniverseHelper.InitializeUniverse(initData);

            Assert.True(UniverseHelper.UniversesAreEqual(expected, result));
        }
        [Fact]
        public void WhenUniverseRegenerated_SwitchState() // TODO: rename once decision is made which class is responsible for this
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
        public void WhenTwoUniversesInstantiated_BeEqual() 
        {
            var gridWidth = 4;
            var gridLength = 4;
            var universe1 = new Universe(gridWidth, gridLength);
            var universe2 = new Universe(gridWidth, gridLength);

            var result = UniverseHelper.UniversesAreEqual(universe1, universe2);

            Assert.True(result);
        }

        [Fact]
        public void WhenUniversesOfDifferentDimensionsInstantiated_NotBeEqual() // TODO: rename - what does the test do? testing universesareequal - may get deleted
        {
            var gridWidth1 = 4;
            var gridLength1 = 4;
            var gridWidth2 = 5;
            var gridLength2 = 4;
            var universe1 = new Universe(gridWidth1, gridLength1);
            var universe2 = new Universe(gridWidth2, gridLength2);

            var result = UniverseHelper.UniversesAreEqual(universe1, universe2);

            Assert.False(result);
        }

        [Fact]
        public void WhenCellIsNull_ThrowException() // TODO: rename - if cell in GetCellNeighbourLocations is null & throws exception
        {
            Cell cell = null;
            var universe = new Universe(3, 3);

            Assert.Throws<NullReferenceException>(() => universe.GetCellNeighbourLocations(cell));
            Assert.Throws<NullReferenceException>(() => universe.CountLiveNeighbours(cell));
        }

        [Fact]
        public void WhenGivenANonBoundaryCell_ReturnCorrectNeighbourLocations()
        {
            var universe = new Universe(3, 3);
            var cell = new Cell(CellState.Dead, 1, 1);
            var expected = new List<Location>() {
                new Location(0, 0), // x + 1, y + 1
                new Location(0, 1),
                new Location(0, 2),
                new Location(1, 0),
                new Location(1, 2),
                new Location(2, 0),
                new Location(2, 1),
                new Location(2, 2)
            };
            
            var result = universe.GetCellNeighbourLocations(cell);

            Assert.True(UniverseHelper.ListsOfLocationsAreEqual(expected, result));
        }

        [Fact]
        public void WhenGivenACellOnBoundaryX_ReturnCorrectNeighbourLocationsListInOrder()
        {
            var universe = new Universe(3, 3);
            var cell = new Cell(CellState.Dead, 0, 1);
            var expected = new List<Location>() {
                new Location(2, 0),
                new Location(2, 1),
                new Location(2, 2),
                new Location(0, 0),
                new Location(0, 2),
                new Location(1, 0),
                new Location(1, 1),
                new Location(1, 2)
            };

            var result = universe.GetCellNeighbourLocations(cell);

            Assert.True(UniverseHelper.ListsOfLocationsAreEqual(expected, result));
        }

        [Fact]
        public void WhenGivenABoundaryCellX_ReturnCorrectNeighbourLocationsListOutOfOrder()
        {
            var universe = new Universe(3, 3);
            var cell = new Cell(CellState.Dead, 0, 1);
            var expected = new List<Location>() {
                new Location(2, 1),
                new Location(2, 0),
                new Location(2, 2),
                new Location(0, 0),
                new Location(0, 2),
                new Location(1, 0),
                new Location(1, 1),
                new Location(1, 2)
            };

            var result = universe.GetCellNeighbourLocations(cell);

            Assert.True(UniverseHelper.ListsOfLocationsAreEqual(expected, result));
        }

        [Fact]
        public void WhenGivenABoundaryCellY_ReturnCorrectNeighbourLocationsListOutOfOrder()
        {
            var universe = new Universe(3, 3);
            var cell = new Cell(CellState.Dead, 1, 0);
            var expected = new List<Location>() {
                new Location(2, 1),
                new Location(2, 0),
                new Location(2, 2),
                new Location(0, 0),
                new Location(0, 2),
                new Location(0, 1),
                new Location(1, 1),
                new Location(1, 2)
            };

            var result = universe.GetCellNeighbourLocations(cell);

            Assert.True(UniverseHelper.ListsOfLocationsAreEqual(expected, result));
        }

        [Fact]
        public void WhenGivenABoundaryCornerCell_ReturnCorrectNeighbourLocationsListOutOfOrder()
        {
            var universe = new Universe(3, 3);
            var cell = new Cell(CellState.Dead, 0, 0);
            var expected = new List<Location>() {
                new Location(2, 1),
                new Location(2, 0),
                new Location(2, 2),
                new Location(0, 1),
                new Location(0, 2),
                new Location(1, 0),
                new Location(1, 1),
                new Location(1, 2)
            };

            var result = universe.GetCellNeighbourLocations(cell);

            Assert.True(UniverseHelper.ListsOfLocationsAreEqual(expected, result));
        }
    }
}