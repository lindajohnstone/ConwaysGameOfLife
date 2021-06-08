using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class OvercrowdingRuleShould
    {
        [Theory]
        [InlineData(8)]
        [InlineData(4)]
        [InlineData(6)]
        public void WhenAnyLiveCellHasMoreThan3LiveNeighbours_ItDies(int numberAliveNeighbours)
        {
            var rule = new OvercrowdingRule();

            var result = rule.ShouldSwitchCellState(numberAliveNeighbours, CellState.Alive);

            Assert.True(result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(-1)]
        public void WhenAnyLiveCellHasLessThanOrEqualTo3LiveNeighbours_ItDoesNotDie(int numberAliveNeighbours)
        {
            var rule = new OvercrowdingRule();

            var result = rule.ShouldSwitchCellState(numberAliveNeighbours, CellState.Alive);

            Assert.False(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(8)]
        public void WhenAnyDeadCellHasAnyLiveNeighbours_ItShouldNeverSwitchState(int numberAliveNeighbours)
        {
            var rule = new OvercrowdingRule();

            var result = rule.ShouldSwitchCellState(numberAliveNeighbours, CellState.Dead);

            Assert.False(result);
        }
    }
}