using System;
using Moq;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class RulesShould
    {
        [Fact]
        public void WhenAnyLiveCellHasFewerThan2LiveNeighbours_ItDies()
        {
            var universe = new Universe(3, 3);
            var rules = new Rules(universe);
            var cell = new Cell(It.IsAny<CellState>(), 1, 1);

            var result = rules.Check(cell);

            Assert.True(result);
        }
    }
}