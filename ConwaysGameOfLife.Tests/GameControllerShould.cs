using System;
using System.Collections.Generic;
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
        public void DisplayUniverse_GivenSuccessfulCreationOfInitialUniverse() // TODO: make theory test
        {
            var input = "3,3";
            _input.GetReadLine(input);
            _controller.CreateInitialUniverse();
            var expected = "💀💀💀\n💀💀💀\n💀💀💀\n";

            _controller.DisplayUniverse();
            var actual = _output.GetLastWriteLine();
            
            Assert.Equal(expected, actual);
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
        [InlineData(new string[] { "0,3", "3,0" }, "1,1")]
        [InlineData(new string[] { "0,3", "3,0", "4 4" }, "3,3")]
        [InlineData(new string[] { "0,3", "3,0", "4 4", ",," }, "10,10")]
        [InlineData(new string[] { "0,3", "3,0", "4 4", ",,", "3,3," }, "10,10")]
        [InlineData(new string[] { "0,3", "3,0", "4 4", ",,", "3,3,", "3,3,3" }, "3,3")]
        [InlineData(new string[] { "0,3", "3,0", "4 4", ",,", "3,3,", "3,3,3", "a,b" }, "3,3")]
        [InlineData(new string[] { "0,3", "3,0", "4 4", ",,", "3,3,", "3,3,3", "a,b", "-1,4" }, "3,3")]
        [InlineData(new string[] { "0,3", "3,0", "4 4", ",,", "3,3,", "3,3,3", "a,b", "-1,4", "10,0" }, "3,3")]
        public void ReturnUniverseString_GivenInvalidInputsFollowedByValidInput(IEnumerable<string> invalidInputs, string validInput)
        {
            _input.GetReadLine(invalidInputs);
            _input.GetReadLine(validInput);
            var expectedOutputLine1 = "Invalid input. Please try again.";
            var expectedOutputLine2 = "Please enter the width & length for the Universe as a number followed by a comma then a number (e.g. '0,0').";

            var result = _controller.CreateValidUniverseString();
            var actualOutputLine1 = _output.GetWriteLine(0);
            var actualOutputLine2 = _output.GetWriteLine(1);

            Assert.Equal(validInput, result);
            Assert.Equal(expectedOutputLine1, actualOutputLine1);
            Assert.Equal(expectedOutputLine2, actualOutputLine2);
        }


        [Theory]
        [InlineData("0,0", "3,3", 3, 3)]
        [InlineData("0,0", "4,3", 4, 3)]
        [InlineData("2,1", "10,5", 10, 5)]
        [InlineData("2,1", "4,6", 4, 6)]
        public void ReturnLocationString_GivenValidInput(string input, string universeInput, int gridWidth, int gridLength)
        {
            InputParser.ParseUniverse(universeInput);
            _input.GetReadLine(input);
            var expected = input;

            var result = _controller.CreateValidLocationString(gridWidth, gridLength);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] { "0,3" }, "2,2", "3,3", 3, 3)]
        [InlineData(new string[] { "3,0" }, "0,0", "3,3" , 3, 3)]
        [InlineData(new string[] { ",," }, "2,2", "3,3", 3, 3)]
        [InlineData(new string[] { "3,3," }, "3,2", "4,3", 4, 3)]
        [InlineData(new string[] { "3,3,3" },"3,2", "4,3", 4, 3)]
        [InlineData(new string[] { "a,b" }, "1,1", "3,3", 3, 3)]
        [InlineData(new string[] { "-1,4" }, "2,0", "3,3", 3, 3)]
        [InlineData(new string[] { "4,-1" }, "2,2", "3,3", 3, 3)]
        //[InlineData(new string[] { "4 4" }, "2,1", "4 3", 4, 3)] // ThrowOverflowOrFormatException
        public void ReturnLocationString_GivenInvalidInputsFollowedByValidInput(IEnumerable<string> invalidInputs, string validInput, string universeString, int gridWidth, int gridLength)
        {
            InputParser.ParseUniverse(universeString);
            _input.GetReadLine(invalidInputs);
            _input.GetReadLine(validInput);
            var expectedOutputLine1 = "Invalid input. Please try again.";
            var expectedOutputLine2 = "Please enter the x, y coordinates for one live cell (e.g. '0,1').";

            var result = _controller.CreateValidLocationString(gridWidth, gridLength);
            var actualOutputLine1 = _output.GetWriteLine(0);
            var actualOutputLine2 = _output.GetWriteLine(1);

            Assert.Equal(validInput, result);
            Assert.Equal(expectedOutputLine1, actualOutputLine1);
            Assert.Equal(expectedOutputLine2, actualOutputLine2);
        }

        [Theory]
        [InlineData(new string[] { "0,0" }, "-9,0", "0,0", -10, 3)] 
        [InlineData(new string[] { "0,0" }, "-9,0", "0,0", 3, -10)] 
        public void ThrowInvalidOperationException_GivenInvalidLocationInputsFollowedByValidLocationInputWithInvalidUniverseInput(IEnumerable<string> invalidInputs, string validInput, string universeString, int gridWidth, int gridLength)
        {
            InputParser.ParseUniverse(universeString);
            _input.GetReadLine(invalidInputs);
            _input.GetReadLine(validInput);
    
            Assert.Throws<InvalidOperationException>(() => _controller.CreateValidLocationString(gridWidth, gridLength));
        }
    }
}