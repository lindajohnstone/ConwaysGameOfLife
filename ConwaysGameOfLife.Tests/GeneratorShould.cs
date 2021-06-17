using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class GeneratorShould
    {
        Generator _generator;
        StubOutput _output;
        StubInput _input;
        public GeneratorShould()
        {
            _output = new StubOutput();
            _input = new StubInput();
            _generator = new Generator(new Universe(3, 3), _output, _input);
        }

        [Fact]
        public void FormatUniverse_GivenUniverseOfAllDeadCells() 
        {
            var expected = "💀💀💀\n💀💀💀\n💀💀💀\n";

            _generator.DisplayUniverse();

            Assert.Equal(expected, _output.GetWriteLine());
        }

        [Theory]
        [InlineData("3,3", 3, 3)]
        [InlineData("10,10", 10, 10)]
        public void SetUniverseDimensions_GivenValidInput(string input, int x, int y)
        {
            var result = _generator.SetUniverseDimensions(input);

            Assert.True(UniverseHelper.UniversesAreEqual(new Universe(x, y), result));
            Assert.Equal(x, result.GridWidth);
            Assert.Equal(y, result.GridLength);
        }

        [Theory]
        [InlineData("0,3")]
        [InlineData("4 4")]
        [InlineData(",,")]
        [InlineData("3,3,")]
        [InlineData("3,3,3")]
        [InlineData("a,b")]
        [InlineData("-1,4")]
        [InlineData("10,0")]
        public void ThrowException_GivenInvalidInput(string input)
        {
            Assert.Throws<InvalidFormatException>(() => _generator.SetUniverseDimensions(input)); ;
        }

        [Fact]
        public void FormatUniverse_FromValidInput()
        {
            var input = "3,3";
            _generator.SetUniverseDimensions(input);
            var expected = "💀💀💀\n💀💀💀\n💀💀💀\n";

            _generator.DisplayUniverse();

            Assert.Equal(expected, _output.GetWriteLine());
        }

        [Theory]
        [InlineData("0,0", 0, 0, 3, 3)]
        [InlineData("0,0", 0, 0, 4, 3)]
        [InlineData("2,1", 2, 1, 10, 5)]
        [InlineData("2,1", 2, 1, 4, 6)]
        public void SetAliveCellLocation_GivenValidInput(string input, int x, int y, int gridWidth, int gridLength)
        {
            var universe = new Universe(gridWidth, gridLength);
            var result = _generator.SetLiveCellLocation(input, universe.GridWidth, universe.GridLength);

            Assert.True(UniverseHelper.LocationsAreEqual(new Location(x, y), result));
        }
    }
}