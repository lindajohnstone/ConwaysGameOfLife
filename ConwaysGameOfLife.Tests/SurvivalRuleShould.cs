using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class SurvivalRuleShould 
    {
        [Theory]
        [InlineData(4)]
        [InlineData(1)]
        [InlineData(8)]
        public void WhenAnyLiveCellDoesNotHave2Or3LiveNeighbours_ItDies(int numberAliveNeighbours)
        {
            var rule = new SurvivalRule();

            var result = rule.ShouldSwitchCellState(numberAliveNeighbours, CellState.Alive);

            Assert.True(result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void WhenAnyLiveCellHas2Or3LiveNeighbours_ItDoesNotDie(int numberAliveNeighbours)
        {
            var rule = new SurvivalRule();

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
            var rule = new SurvivalRule();

            var result = rule.ShouldSwitchCellState(numberAliveNeighbours, CellState.Dead);

            Assert.False(result);
        }
    }
}