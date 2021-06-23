using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class GameControllerShould
    {
        StubOutput _output;

        StubInput _input;

        GameController _controller;
        public GameControllerShould()
        {
            _output = new StubOutput();
            _input = new StubInput();
            _controller = new GameController(_input, _output);
        }
        [Fact]
        public void DisplayUniverse_GivenSuccessfulCreationOfInitialUniverse() 
        {
            var input = "3,3";
            _input.GetReadLine(input);
            _controller.CreateInitialUniverse();
            var expected = "💀💀💀\n💀💀💀\n💀💀💀\n";

            _controller.DisplayUniverse();
            var lastLine = _output.GetLastWriteLine();
            Assert.Equal(expected, lastLine);
        }

        [Theory]
        [InlineData("3,3")]
        [InlineData("10,10")]
        public void ReturnUniverseString_GivenValidInput(string input)
        {
            InputParser.ParseUniverse(input);
            _input.GetReadLine(input);
            var expected = input;

            var result = _controller.CreateValidUniverseString();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("0,3")]
        // [InlineData("4 4")]
        // [InlineData(",,")]
        // [InlineData("3,3,")]
        // [InlineData("3,3,3")]
        // [InlineData("a,b")]
        // [InlineData("-1,4")]
        // [InlineData("10,0")]
        public void NotReturnUniverseString_GivenInvalidInput(string input)
        {
            InputParser.ParseUniverse(input);
            _input.GetReadLine(input);
            var expected = "Invalid input. Please try again. Please enter the x, y coordinates for one live cell (e.g. '0,1').";

            var result = _controller.CreateValidUniverseString();

            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData("0,0", 3, 3)]
        [InlineData("0,0", 4, 3)]
        [InlineData("2,1", 10, 5)]
        [InlineData("2,1", 4, 6)]
        public void ReturnLocationString_GivenValidInput(string input, int gridWidth, int gridLength)
        {
            InputParser.ParseUniverse(input);
            _input.GetReadLine(input);
            var expected = input;

            var result = _controller.CreateValidLocationString(gridWidth, gridLength);

            Assert.Equal(expected, result);
        }

        //TODO: how to test error message in CreateValidLocationString
    }
}