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

        [Fact]
        public void SetUniverseDimensions_FromValidUserInput()
        {
            var userInput = "3,3";

            var result = _generator.SetUniverseDimensions(userInput);

            Assert.True(UniverseHelper.UniversesAreEqual(new Universe(3, 3), result));
        }
    }
}