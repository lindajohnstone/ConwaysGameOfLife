using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class GeneratorShould
    {
        private Generator _generator;
        public GeneratorShould()
        {
            _generator = new Generator();
        }

        [Theory]
        [InlineData("XXX", "XXX", "XXX")]
        [InlineData("XXX", "OXX", "XXX")]
        [InlineData("OOO", "OOO", "OOO")]
        [InlineData("OXX", "XXX", "XXO")]
        [InlineData("XOXX", "XXXX", "XOXX")]
        [InlineData("XXXX", "XXXX", "XXXX")]
        [InlineData("XXXX", "OXXX", "XXXX")]
        public void ReturnNewListOfCells_From(params string[] rows)
        {
            var initData = String.Join(Environment.NewLine, rows);
            var universe = UniverseHelper.InitializeUniverse(initData);
            var expected = universe.Cells;

            var result = _generator.AddCellsToList(universe.Cells);
            
            Assert.True(UniverseHelper.ListsOfCellsAreEqual(expected, result));
        }

        [Fact]
        public void testName()
        {
            var cell = new Cell(CellState.Dead, 0, 0);

            
        }
    }
}