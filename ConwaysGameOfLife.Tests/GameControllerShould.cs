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
        // [Theory]
        // [InlineData("3,3", "💀💀💀\n💀💀💀\n💀💀💀\n")]
        // [InlineData("3,2", "💀💀💀\n💀💀💀\n")]
        // [InlineData("9,9", "💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n💀💀💀💀💀💀💀💀💀\n")]
        // public void DisplayUniverse_GivenSuccessfulCreationOfInitialUniverse(string input, string expected)
        // {
        //     _input.GetReadLine(input);
        //     _controller.CreateInitialUniverse();

        //     _controller.DisplayUniverse();
        //     var actual = _output.GetLastWriteLine();

        //     Assert.Equal(expected, actual);
        // }

        // [Theory]
        // [InlineData("0,0", "3,3")]
        // [InlineData("0,0", "4,3")]
        // [InlineData("2,1", "10,5")]
        // [InlineData("2,1", "4,6")]
        // public void ReturnLocationString_GivenValidInput(string input, string universeInput)
        // {
        //     _input.GetReadLine(universeInput);
        //     _controller.CreateInitialUniverse();
        //     _input.GetReadLine(input);
        //     var expected = input;

        //     var result = _controller.CreateValidLocationString();

        //     Assert.Equal(expected, result);
        // }

        // [Theory]
        // [InlineData(new string[] { "0,3" }, "2,2", "3,3")]
        // [InlineData(new string[] { "3,0" }, "0,0", "3,3")]
        // [InlineData(new string[] { ",,", ";;" }, "2,2", "10,10")] // failing
        // [InlineData(new string[] { "3,3,", "3,4;" }, "3,2", "4,4")] // failing
        // [InlineData(new string[] { "3,3,3" }, "3,2", "5,4")]
        // [InlineData(new string[] { "a,b", "0,a", "o,9" }, "1,1", "2,2")]
        // [InlineData(new string[] { "-1,4", "a,b", "0,a", "o,9" }, "2,0", "3,3")] // failing
        // [InlineData(new string[] { "4,-1" }, "2,2", "5,5")]
        // [InlineData(new string[] { "4 4" }, "2,1", "3,3")]
        // public void ReturnLocationString_GivenInvalidInputsFollowedByValidInput(IEnumerable<string> invalidInputs, string validInput, string universeInput)
        // {
        //     _input.GetReadLine(universeInput);
        //     _controller.CreateInitialUniverse();
        //     _input.GetReadLine(invalidInputs);
        //     _input.GetReadLine(validInput);
        //     var invalidOutputMessageLine1 = "Invalid input. Please try again.";
        //     var invalidOutputMessageLine2 = "Please enter the x, y coordinates for one live cell (e.g. '0,1').";
        //     var count = invalidInputs.Count();

        //     var result = _controller.CreateValidLocationString();

        //     for (var i = 1; i <= count; i += 2)
        //     {
        //         var actualOutput = _output.GetWriteLine(i);
        //         Assert.Equal(invalidOutputMessageLine1, actualOutput);
        //         var actualOutputLine2 = _output.GetWriteLine(i + 1);
        //         Assert.Equal(invalidOutputMessageLine2, actualOutputLine2);
        //     }

        //     Assert.Equal(validInput, result);
        // }

        // [Fact]
        // public void SetLiveCellLocation_GivenValidInput()
        // {
        //     var universeInput = "3,3";
        //     var input = "1,2";
        //     _input.GetReadLine(universeInput);
        //     _controller.CreateInitialUniverse();
        //     _input.GetReadLine(input);
        //     var locationString = _controller.CreateValidLocationString();
        //     var location = InputParser.ParseLocation(locationString);

        //     var result = _controller.ReturnUniverseAfterSettingLiveCellLocation(location);

        //     Assert.Equal(CellState.Alive, result.GetCellAtLocation(location).CellState);
        // }

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
        public void DisplayUniverse_GivenInvalidInputsFollowedByValidInput(IEnumerable<string> invalidInputs, string validInput, string expected)
        {
            _input.GetReadLine(invalidInputs);
            _input.GetReadLine(validInput);
            _input.GetReadLine("q");

            _controller.Run();
            var actual = _output.GetLastWriteLine();

            Assert.Equal(expected, actual);
        }
    }
}