using System;
using Xunit;
using ConwaysGameOfLife;

namespace ConwaysGameOfLife.Tests
{
    public class CellShould
    {
        [Fact]
        public void WhenInitialized_BeDead()
        {
            var cell = new Cell();
            var result = cell.IsAlive();
            Assert.False(result);
        }

        
    }
}
