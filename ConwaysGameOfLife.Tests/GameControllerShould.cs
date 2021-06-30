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
            var expectedOutput = "Game of Life has ended.";
            var input = "q";
            _input.GetReadLine(input);

            _controller.Run();

            Assert.Equal(expectedOutput, _output.GetLastOutput());
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

            Assert.Equal(expectedOutput, _output.GetLastOutput());
        }

        [Theory]
        [InlineData("5,5", "0,5")]
        [InlineData("5,5", "0,4")]
        public void EndGame_GivenQInputDuringLocationInput(string universeInput, params string[] inputs)
        {
            var expectedOutput = "Game of Life has ended.";
            _input.GetReadLine(universeInput);
            _input.GetReadLine(inputs);
            _input.GetReadLine("q");

            _controller.Run();

            Assert.Equal(expectedOutput, _output.GetLastOutput());
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
            var actual = _output.GetLastUniverseOutput();

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
            var actual = _output.GetLastUniverseOutput();

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
            var actual = _output.GetLastUniverseOutput();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("3,3", "💟💀💀\n💀💀💟\n💀💀💀\n", "2,1", "0,0")]
        [InlineData("3,3", "💟💀💀\n💀💀💀\n💟💀💀\n", "0,2", "0,0")]
        [InlineData("3,2", "💟💀💀\n💟💀💀\n", "0,0", "0,1")]
        public void DisplayUniverse_GivenValidLocationStrings(string universeInput, string expected, params string[] inputs)
        {
            _input.GetReadLine(universeInput);
            _input.GetReadLine(inputs);
            _input.GetReadLine("q");

            _controller.Run();
            var actual = _output.GetLastUniverseOutput();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("3,3", "💟💀💀\n💀💀💟\n💀💀💀\n", "2,1", "0,3", "0,0")]
        [InlineData("3,3", "💟💀💀\n💀💀💀\n💟💀💟\n", "0,2", "0,0", "0,3", "2,2")]
        [InlineData("3,2", "💟💟💀\n💟💀💀\n", "0,0", "0,1", "0,2", "1,0")]
        [InlineData("3,5", "💟💀💀\n💀💀💀\n💟💀💟\n💟💟💀\n💟💀💀\n", "0,0", "5,3", "5,0", "1,3", "0,4", "0,2", "0,3", "2,2")]
        [InlineData("3,3", "💀💀💀\n💀💀💀\n💀💀💀\n", "0,0", "0,0")]
        public void DisplayUniverse_GivenValidAndInvalidLocationStrings(string universeInput, string expected, params string[] inputs)
        {
            _input.GetReadLine(universeInput);
            _input.GetReadLine(inputs);
            _input.GetReadLine("q");

            _controller.Run();
            var actual = _output.GetLastUniverseOutput();

            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("5,5", "💀💀💀💀💀\n💀💀💀💀💀\n💀💟💟💟💀\n💀💀💀💀💀\n💀💀💀💀💀\n", "1,2", "2,2", "3,2")]
        [InlineData("4,4", "💀💀💀💀\n💀💟💟💀\n💀💟💟💀\n💀💀💀💀\n", "1,2", "1,1", "2,2", "2,1")]
        [InlineData("6,6", "💀💀💀💀💀💀\n💀💀💟💟💀💀\n💀💟💀💀💟💀\n💀💀💟💟💀💀\n💀💀💀💀💀💀\n💀💀💀💀💀💀\n", "1,3", "2,2", "2,3", "3,2", "3,3", "4,2")] // TODO: failing
        public void DisplayUniverse_GivenPInput(string universeInput, string expected, params string[] inputs)
        {
            _input.GetReadLine(universeInput);
            _input.GetReadLine(inputs);
            _input.GetReadLine("p");
            _input.GetReadLine("q");

            _controller.Run();
            var actual = _output.GetLastUniverseOutput();

            Assert.Equal(expected, actual);
        }
    }
}