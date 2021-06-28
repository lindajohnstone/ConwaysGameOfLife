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

        [Theory]
        [MemberData(nameof(UniverseMemberData.CellsInUniverse), MemberType = typeof(UniverseMemberData))]
        public void WhenInitialized_FindCellStateOfCell(Cell cell)
        {
            var universe = new Universe(3, 3);
            var expected = CellState.Dead;

            var checkedCell = universe.GetCellAtLocation(cell.Location);
            var result = checkedCell.CellState;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("XXX", "XXX", "XXX", 1, 1, 0)]
        [InlineData("XXX", "OXX", "XXX", 1, 1, 1)]
        [InlineData("OOO", "OOO", "OOO", 1, 1, 8)]
        [InlineData("OXX", "XXX", "XXO", 1, 1, 2)]
        [InlineData("XOOX", "XXXX", "XXXX", 1, 1, 2)]
        [InlineData("XXXX", "XXXX", "XXXX", 1, 1, 0)]
        [InlineData("XXXX", "OXXX", "XXXX", 1, 1, 1)]
        public void ReturnCountOfLiveNeighbours_GivenNonBoundaryCoordinates(string row1, string row2, string row3, int x, int y, int expected)
        {
            var initData = row1 + Environment.NewLine +
                            row2 + Environment.NewLine +
                            row3;
            var universe = UniverseHelper.InitializeUniverse(initData);
            var location = new Location(x, y);
            var cell = universe.GetCellAtLocation(location);

            var result = universe.CountLiveNeighbours(cell);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("XXX", "XXX", "XXX", 0, 1, 0)]
        [InlineData("XXX", "OXX", "XXX", 1, 2, 1)]
        [InlineData("OOO", "OOO", "OOO", 2, 1, 8)]
        [InlineData("OXX", "XXX", "XXO", 2, 1, 2)]
        [InlineData("XOXX", "XXXX", "XOXX", 0, 0, 2)]
        [InlineData("XXXX", "XXXX", "XXXX", 3, 0, 0)]
        [InlineData("XXXX", "OXXX", "XXXX", 1, 0, 1)]
        public void ReturnCountOfLiveNeighbours_GivenBoundaryCoordinates(string row1, string row2, string row3, int x, int y, int expected)
        {
            var initData = row1 + Environment.NewLine +
                            row2 + Environment.NewLine +
                            row3;
            var location = new Location(x, y);
            var universe = UniverseHelper.InitializeUniverse(initData);
            var cell = universe.GetCellAtLocation(location);

            var result = universe.CountLiveNeighbours(cell);

            Assert.Equal(expected, result);
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
        public void WhenGivenALocation_ReturnCorrectCell()
        {
            var gridWidth = 4;
            var gridLength = 4;
            var x = 0;
            var y = 0;
            var universe = new Universe(gridWidth, gridLength);
            var location = new Location(x, y);

            var result = universe.GetCellAtLocation(location);

            Assert.Equal(0, result.Location.X);
            Assert.Equal(0, result.Location.Y);
            Assert.Equal(CellState.Dead, result.CellState);
        }

        [Fact]
        public void WhenCellIsNull_ThrowException() // TODO: rename - if cell in GetCellNeighbourLocations is null & throws exception
        {
            Cell cell = null;
            var universe = new Universe(3, 3);

            Assert.Throws<NullReferenceException>(() => universe.CountLiveNeighbours(cell));
        }
    }
}