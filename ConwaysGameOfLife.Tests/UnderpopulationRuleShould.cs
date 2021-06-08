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
            var initData = "XXX" + Environment.NewLine +
                            "XOX" + Environment.NewLine +
                            "XXX";
            var rules = new UnderpopulationRule(UniverseHelper.InitializeUniverse(initData));
            var x = 1;
            var y = 1;
            var result = rules.ShouldSwitchCellState(x, y);

            Assert.True(result);
        }

        [Fact]
        public void WhenAnyDeadCellHasFewerThan2LiveNeighbours_ItDoesNotDie()
        {
            var initData = "OXX" + Environment.NewLine +
                            "XXX" + Environment.NewLine +
                            "XXX";
            var rules = new UnderpopulationRule(UniverseHelper.InitializeUniverse(initData));
            var x = 1;
            var y = 1;
            var result = rules.ShouldSwitchCellState(x, y);

            Assert.False(result);
        }

        [Fact]
        public void WhenAnyLiveCellHas2LiveNeighbours_ItDoesNotDie()
        {
            var initData = "OXX" + Environment.NewLine +
                            "OXX" + Environment.NewLine +
                            "XXX";
            var rules = new UnderpopulationRule(UniverseHelper.InitializeUniverse(initData));
            var x = 1;
            var y = 1;
            var result = rules.ShouldSwitchCellState(x, y);

            Assert.False(result);
        }
    }
}