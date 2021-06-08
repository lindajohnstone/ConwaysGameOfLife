using System;
using System.Collections.Generic;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class LocationShould // TODO: all tests relate to universehelper methods ?? delete class?
    {
        [Theory]
        [InlineData(0, 0, 0, 0)]
        public void WhenTwoLocationsInstantiated_BeEqual(int x1, int y1, int x2, int y2)
        {
            var location1 = new Location(x1, y1);
            var location2 = new Location(x2, y2);

            var result = UniverseHelper.LocationsAreEqual(location1, location2);

            Assert.True(result);
        }

        [Theory]
        [InlineData(0, 0, 1, 0)]
        public void WhenTwoLocationsInstantiated_NotBeEqual(int x1, int y1, int x2, int y2)
        {
            var location1 = new Location(x1, y1);
            var location2 = new Location(x2, y2);

            var result = UniverseHelper.LocationsAreEqual(location1, location2);

            Assert.False(result);
        }

        [Fact]
        public void GivenTwoListsOfLocations_AreEqual()
        {
            var expected = new List<Location>(){
                new Location(0, 0),
                new Location(0, 1),
                new Location(0, 2),
                new Location(1, 0),
                new Location(1, 2),
                new Location(2, 0),
                new Location(2, 1),
                new Location(2, 2)
            };

            var result = new List<Location>(){
                new Location(0, 0),
                new Location(0, 1),
                new Location(0, 2),
                new Location(1, 0),
                new Location(1, 2),
                new Location(2, 0),
                new Location(2, 1),
                new Location(2, 2)
            };

            Assert.True(UniverseHelper.ListsOfLocationsAreEqual(expected, result));
        }

        [Fact]
        public void GivenTwoListsOfLocations_AreNotEqual()
        {
            var expected = new List<Location>(){
                new Location(0, 0),
                new Location(0, 1),
                new Location(0, 2),
                new Location(1, 0),
                new Location(1, 2),
                new Location(2, 0),
                new Location(2, 1),
                new Location(2, 2)
            };

            var result = new List<Location>(){
                new Location(0, 0),
                new Location(0, 1),
                new Location(0, 2),
                new Location(1, 1),
                new Location(1, 2),
                new Location(2, 0),
                new Location(2, 1),
                new Location(2, 2)
            };

            Assert.False(UniverseHelper.ListsOfLocationsAreEqual(expected, result));
        }
    }
}