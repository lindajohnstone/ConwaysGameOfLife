using System;
using Moq;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class UnderpopulationRuleShould
    {
        UnderpopulationRule _rule;
        public UnderpopulationRuleShould()
        {
            _rule = new UnderpopulationRule();
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void WhenAnyLiveCellHasFewerThan2LiveNeighbours_ItDies(int numberAliveNeighbours)
        {
            var result = _rule.ShouldSwitchCellState(numberAliveNeighbours, CellState.Alive);

            Assert.True(result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(8)]
        public void WhenAnyLiveCellHas2OrMoreLiveNeighbours_ItDoesNotDie(int numberAliveNeighbours)
        {
            var result = _rule.ShouldSwitchCellState(numberAliveNeighbours, CellState.Alive);

            Assert.False(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(8)]
        public void WhenAnyDeadCellHasAnyLiveNeighbours_ItShouldNeverSwitchState(int numberAliveNeighbours)
        {
            var result = _rule.ShouldSwitchCellState(numberAliveNeighbours, CellState.Dead);

            Assert.False(result);
        }
    }
}