using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class ReproductionRuleShould 
    {
        ReproductionRule rule;
        public ReproductionRuleShould()
        {
            rule = new ReproductionRule();
        }

        [Theory]
        [InlineData(3)]
        public void WhenAnyDeadCellHasExactly3LiveNeighbours_ItLives(int numberAliveNeighbours)
        {
            var result = rule.ShouldSwitchCellState(numberAliveNeighbours, CellState.Dead);

            Assert.True(result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(0)]
        [InlineData(8)]
        public void WhenAnyDeadCellHasMoreOrLessThan3LiveNeighbours_ItDies(int numberAliveNeighbours)
        {
            var result = rule.ShouldSwitchCellState(numberAliveNeighbours, CellState.Alive);

            Assert.False(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(8)]
        public void WhenAnyLiveCellHasAnyLiveNeighbours_ItShouldNeverSwitchState(int numberAliveNeighbours)
        {
            var result = rule.ShouldSwitchCellState(numberAliveNeighbours, CellState.Alive);

            Assert.False(result);
        }
    }
}