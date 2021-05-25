using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class LocationShould
    {
        [Fact]
        public void WhenXAndYAreSame_BeEqual()
        {
            var x = 0;
            var y = 0;
            var location = new Location(x, y);
            var one = location;
            var two = new Location(0, 0);
            var result = (one.Equals(two));
            Assert.True(result);
        }
    }
}