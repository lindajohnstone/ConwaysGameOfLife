using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class GameControllerShould
    {
        StubOutput _output;

        StubInput _input;

        public GameControllerShould()
        {
            _output = new StubOutput();
            _input = new StubInput();
        }
        [Fact]
        public void DisplayUniverse_GivenUniverseOfAllDeadCells() 
        {
            var input = "3,3";
            var controller = new GameController(_input, _output);
            InputParser.ParseUniverse(input);
            var expected = "💀💀💀\n💀💀💀\n💀💀💀\n";

            controller.DisplayUniverse();

            Assert.Equal(expected, _output.GetWriteLine());
        }

        [Theory]
        [InlineData("3,3")]
        [InlineData("10,10")]
        public void ReturnUniverseString_GivenValidInput(string input)
        {
            var controller = new GameController(_input, _output);
            InputParser.ParseUniverse(input);
            _input.GetReadLine(input);
            var expected = input;

            var result = controller.CreateValidUniverseString();

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
            var controller = new GameController(_input, _output);
            InputParser.ParseUniverse(input);
            _input.GetReadLine(input);
            var expected = input;

            var result = controller.CreateValidUniverseString();

            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData("0,0", 3, 3)]
        [InlineData("0,0", 4, 3)]
        [InlineData("2,1", 10, 5)]
        [InlineData("2,1", 4, 6)]
        public void ReturnLocationString_GivenValidInput(string input, int gridWidth, int gridLength)
        {
            var controller = new GameController(_input, _output);
            InputParser.ParseUniverse(input);
            _input.GetReadLine(input);
            var expected = input;

            var result = controller.CreateValidLocationString(gridWidth, gridLength);

            Assert.Equal(expected, result);
        }

        //TODO: how to test error message in CreateValidLocationString
    }
}