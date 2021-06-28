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
            var actual = _output.GetLastWriteLine();

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
            var actual = _output.GetLastWriteLine();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EndGame_GivenInvalidInputOfQ()
        {
            _input.GetReadLine("q");
            var expected = "Game of Life has ended.";

            _controller.Run();
            var actual = _output.GetLastWriteLine();

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
            var actual = _output.GetLastWriteLine();

            Assert.Equal(expected, actual);
        }
    }
}