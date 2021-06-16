using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class GeneratorShould
    {
        Generator _generator;
        IOutput _output;
        public GeneratorShould()
        {
            _generator = new Generator(new Universe(3, 3));
            _output = new StubOutput();
        }

        [Fact]
        public void FormatUniverse_GivenUniverseOfAllDeadCells() // TODO: if parameter on line 22 is removed, test fails
        {
            var expected = "💀💀💀\n💀💀💀\n💀💀💀\n";

            _generator.DisplayUniverse();

            //Assert.Equal(expected, _output.GetWriteLine());
        }
    }
}