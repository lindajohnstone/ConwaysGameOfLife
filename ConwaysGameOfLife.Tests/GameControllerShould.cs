using System;
using System.Collections.Generic;
using System.Linq;
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
        public void EndRunImmediately_GivenQInput()
        {
            var expectedOutput = "Please enter the width & length for the Universe as a number followed by a comma then a number (e.g. '0,0').";
            var input = "q";
            _input.GetReadLine(input);

            _controller.Run();

            Assert.Equal(expectedOutput, _output.GetLastWriteLine());
        }

        [Theory]
        [InlineData("3,3", "💀💀💀\n💀💀💀\n💀💀💀\n")]
        [InlineData("3,2", "💀💀💀\n💀💀💀\n")]
        [InlineData("9,9", "💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n")]
        [InlineData("3,4", "💀💀💀\n💀💀💀\n💀💀💀\n💀💀💀\n")]
        public void DisplayUniverse_GivenValidUniverseString(string input, string expected)
        {
            _input.GetReadLine(input);
            _input.GetReadLine("q");

            _controller.Run();
            var index = _output._outputList.Count - 2;
            var actual = _output.GetWriteLine(index);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new string[] { "0,3", "3,0" }, "3,3", "💀💀💀\n💀💀💀\n💀💀💀\n")]
        [InlineData(new string[] { "0;3", "3-0", "4 4" }, "3,3", "💀💀💀\n💀💀💀\n💀💀💀\n")]
        [InlineData(new string[] { ",," }, "9,9", "💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n")]
        [InlineData(new string[] { "3,3," }, "9,9", "💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n")]
        [InlineData(new string[] { "3,3,3", "3;3;" }, "3,3", "💀💀💀\n💀💀💀\n💀💀💀\n")]
        [InlineData(new string[] { "a,b" }, "3,3", "💀💀💀\n💀💀💀\n💀💀💀\n")]
        [InlineData(new string[] { "-1,4", "4,-1" }, "3,3", "💀💀💀\n💀💀💀\n💀💀💀\n")]
        [InlineData(new string[] { "10,0", "0,10" }, "3,3", "💀💀💀\n💀💀💀\n💀💀💀\n")]
        public void CreateUniverse_GivenInvalidInputsFollowedByValidInput(IEnumerable<string> invalidInputs, string validInput, string expected)
        {
            _input.GetReadLine(invalidInputs);
            _input.GetReadLine(validInput);
            _input.GetReadLine("q");

            _controller.Run();
            var index = _output._outputList.Count - 2;
            var actual = _output.GetWriteLine(index);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("3,3", "2,1", "💀💀💀\n💀💀💟\n💀💀💀\n")] 
        [InlineData("3,3", "0,2", "💀💀💀\n💀💀💀\n💟💀💀\n")] 
        [InlineData("3,2", "0,0", "💟💀💀\n💀💀💀\n")]
        public void DisplayUniverse_GivenValidLocationString(string universeInput, string locationInput, string expected)
        {
            _input.GetReadLine(universeInput);
            _input.GetReadLine(locationInput);
            _input.GetReadLine("q");

            _controller.Run();
            var index = _output._outputList.Count - 2;
            var actual = _output.GetWriteLine(index);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("3,3")]
        [InlineData("0,3", "3,0")]
        public void EndGame_GivenQInputDuringUniverseInput(params string[] inputs)
        {
            var expectedOutput = "Game of Life has ended.";
            _input.GetReadLine(inputs);
            _input.GetReadLine("q");

            _controller.Run();

            Assert.Equal(expectedOutput, _output.GetLastWriteLine());
        }

        [Theory]
        [InlineData("5,5", "0,5")]
        [InlineData("5,5", "0,4")]
        //[InlineData("5,5", "0,5")]
        public void EndGame_GivenQInputDuringLocationInput(string universeInput, params string[] inputs)
        {
            var expectedOutput = "Game of Life has ended.";
            _input.GetReadLine(inputs);
            _input.GetReadLine("q");

            _controller.Run();

            Assert.Equal(expectedOutput, _output.GetLastWriteLine());
        }
    }
}