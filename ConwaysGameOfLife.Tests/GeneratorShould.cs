using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class GeneratorShould
    {
        [Theory]
        [InlineData("XXX", "XXX", "XXX")]
        [InlineData("XX", "XX", "XX")]
        [InlineData("XXXX", "XXXX", "XXXX")]
        public void ReturnNewListOfCells_FromOldUniverse(params string[] rows)
        {
            var initData = String.Join(Environment.NewLine, rows);
            var universe = UniverseHelper.InitializeUniverse(initData);
            var generator = new Generator(universe);
            var expected = universe.Cells;

            var result = generator.GenerateNewUniverse();

            Assert.True(UniverseHelper.ListsOfCellsAreEqual(expected, result.Cells));
        }

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