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
        public void FormatUniverse_GivenUniverseOfAllDeadCells() 
        {
            var universe = new Universe(3, 3);
            var controller = new GameController(universe, _output, _input);
            var expected = "💀💀💀\n💀💀💀\n💀💀💀\n";

            controller.DisplayUniverse();

            Assert.Equal(expected, _output.GetWriteLine());
        }

        [Theory]
        [InlineData("3,3", 3, 3)]
        [InlineData("10,10", 10, 10)]
        public void ReturnValidUniverseString_GivenValidInput(string input, int gridWidth, int gridLength)
        {
            var universe = new Universe(gridWidth, gridLength);
            var controller = new GameController(universe, _output, _input);
            _input.WithReadLine(input);
            var expected = input;

            var result = controller.CreateValidUniverseString();

            Assert.Equal(expected, result);
        }

        //TODO: how to test error message in CreateValidUniverseString

        [Theory]
        [InlineData("0,0", 0, 0, 3, 3)]
        [InlineData("0,0", 0, 0, 4, 3)]
        [InlineData("2,1", 2, 1, 10, 5)]
        [InlineData("2,1", 2, 1, 4, 6)]
        public void SetAliveCellLocation_GivenValidInput(string userInput, int x, int y, int gridWidth, int gridLength)
        {
            var universe = new Universe(gridWidth, gridLength);
            var controller = new GameController(universe, _output, _input);
            
            var result = controller.SetLiveCellLocation(userInput);

            Assert.True(UniverseHelper.LocationsAreEqual(new Location(x, y), result));
        }

        [Theory]
        [InlineData("0,3", 3, 3)]
        [InlineData("3,0", 3, 3)]
        [InlineData("4 4", 4, 3)]
        [InlineData(",,", 3, 3)]
        [InlineData("3,3,", 4, 3)]
        [InlineData("3,3,3", 4, 3)]
        [InlineData("a,b", 3, 3)]
        [InlineData("-1,4", 3, 3)]
        [InlineData("4,-1", 3, 3)]
        // [InlineData("0,0", -10, 3)] // TODO: tests line 89 + 90 fail - are these tests required as the universe has already been validated?
        // [InlineData("0,0", 3, -10)]
        public void ThrowException_GivenInvalidLocationCoordinates(string userInput, int gridWidth, int gridLength)
        {
            var universe = new Universe(gridWidth, gridLength);
            var controller = new GameController(universe, _output, _input);

            Assert.Throws<InvalidFormatException>(() => controller.SetLiveCellLocation(userInput));
        }
    }
}