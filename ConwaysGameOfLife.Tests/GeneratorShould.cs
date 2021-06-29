using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class GeneratorShould
    {
        [Theory]
        [InlineData("XXX", "XXX", "XXX")]
        [InlineData("XXX", "OXX", "XXX")]
        [InlineData("OOO", "OOO", "OOO")]
        [InlineData("OXX", "XXX", "XXO")]
        [InlineData("XOXX", "XXXX", "XOXX")]
        [InlineData("XXXX", "XXXX", "XXXX")]
        [InlineData("XXXX", "OXXX", "XXXX")]
        public void ReturnNewListOfCells_FromOldUniverse(params string[] rows)
        {
            var initData = String.Join(Environment.NewLine, rows);
            var universe = UniverseHelper.InitializeUniverse(initData);
            var generator = new Generator(universe);
            var expected = universe.Cells;

            var result = generator.GenerateCells(universe.Cells);

            Assert.True(UniverseHelper.ListsOfCellsAreEqual(expected, result));
        }

        // [Theory]
        // [InlineData(CellState.Dead, 0, 0)]
        // [InlineData(CellState.Alive, 0, 1)]
        // [InlineData(CellState.Dead, 0, 2)]
        // [InlineData(CellState.Alive, 2, 0)]
        // public void ReturnNewCell_GivenUniverse(CellState state, int x, int y)
        // {

        //     var cell = new Cell(state, x, y);
        //     var expected = cell;

        //     var result = _generator.GenerateNewCell(cell);

        //     Assert.True(UniverseHelper.CellsAreEqual(expected, result));
        // }

        // [Fact]
        // public void testName()
        // {
        //     var rows = new string[]
        //     {
        //         "XXX", "XXX", "XXX",
        //     };
        //     var initData = String.Join(Environment.NewLine, rows);
        //     var universe = UniverseHelper.InitializeUniverse(initData);
        //     var cell = universe.GetCellAtLocation(new Location(0, 0));
        //     var numberOfLiveNeighbours = universe.CountLiveNeighbours(cell);
        //     var state = cell.CellState;

        // }

        [Theory]
        [InlineData(3, 3)]
        [InlineData(10, 10)]
        [InlineData(5, 3)]
        public void CreateNewUniverse_FromInitialUniverse(int gridWidth, int gridLength)
        {
            var universe = new Universe(gridWidth, gridLength);
            var generator = new Generator(universe);

            var result = generator.GenerateNewUniverse();

            Assert.True(UniverseHelper.UniversesAreEqual(universe, result));
        }

        [Fact]
        public void CreateNewUniverse_FromUniverseWithOneLiveCell()
        {
            var rows = new string[]
            {
                "OXX",
                "XXX",
                "XXX"
            };
            var initData = String.Join(Environment.NewLine, rows);
            var universe = UniverseHelper.InitializeUniverse(initData);
            var generator = new Generator(universe);
            var expected = new Universe(3, 3);

            var result = generator.GenerateNewUniverse();

            Assert.True(UniverseHelper.UniversesAreEqual(expected, result));
        }

        [Fact]
        public void CreateNewUniverse_FromUniverseWithLiveCells()
        {
            var rows = new string[]
            {
                "OXX",
                "OXX",
                "OXX"
            };
            var initData = String.Join(Environment.NewLine, rows);
            var universe = UniverseHelper.InitializeUniverse(initData);
            var generator = new Generator(universe);
            var rowsNextUniverse = new string[]
            {
                "OOO",
                "OOO",
                "OOO"
            };
            var initDataNextUniverse = String.Join(Environment.NewLine, rowsNextUniverse);
            var nextUniverse = UniverseHelper.InitializeUniverse(initDataNextUniverse);
            var expected = nextUniverse;

            var result = generator.GenerateNewUniverse();

            Assert.True(UniverseHelper.UniversesAreEqual(expected, result));
        }
    }
}