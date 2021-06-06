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

        [Fact]
        public void WhenXAndYAreSame_BeEqualOperator()
        {
            var x = 0;
            var y = 0;
            var location = new Location(x, y);
            var one = location;
            var two = new Location(0, 0);

            var result = (one == two);

            Assert.True(result);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, true)]
        [InlineData(0, 0, 1, 0, false)]
        public void WhenTwoLocationsInstantiated_BeEqual(int x1, int y1, int x2, int y2, bool expected)
        {
            var location1 = new Location(x1, y1);
            var location2 = new Location(x2, y2);

            var result = UniverseHelper.LocationsAreEqual(location1, location2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0, 1, 0, false)]
        public void WhenTwoLocationsInstantiated_NotBeEqual(int x1, int y1, int x2, int y2, bool expected)
        {
            var location1 = new Location(x1, y1);
            var location2 = new Location(x2, y2);

            var result = UniverseHelper.LocationsAreEqual(location1, location2);

            Assert.Equal(expected, result);
        }
    }
}