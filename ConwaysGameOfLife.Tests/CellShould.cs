using System;
using Xunit; 

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
