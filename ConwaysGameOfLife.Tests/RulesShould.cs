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
            var initData =  "XXX" + Environment.NewLine +
                            "XOX" + Environment.NewLine +
                            "XXX";
            var rules = new Underpopulation(UniverseHelper.InitializeUniverse(initData));
            var x = 1;
            var y = 1;
            var result = rules.Check(x, y);

            Assert.True(result);
        }

        [Fact]
        public void WhenAnyLiveCellHas2LiveNeighbours_ItDoesNotDie()
        {
            var initData =  "XXO" + Environment.NewLine +
                            "XOX" + Environment.NewLine +
                            "XXO";
            var rules = new Underpopulation(UniverseHelper.InitializeUniverse(initData));
            var x = 1;
            var y = 1;

            var result = rules.Check(x, y);

            Assert.False(result);
        }
    }
}