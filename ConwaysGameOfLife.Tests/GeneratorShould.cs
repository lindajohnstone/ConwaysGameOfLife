using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class GeneratorShould
    {
        Generator _generator;
        public GeneratorShould()
        {
            _generator = new Generator(new Universe(3, 3));
        }

        [Fact]
        public void WhenUniverseCreatedInitially_DisplayUniverse() // TODO: if parameter on line 19 is removed, test fails
        {
            var output = new StubOutput();
            var expected = "💀💀💀\n💀💀💀\n💀💀💀\n";

            _generator.DisplayUniverse(output);

            Assert.Equal(expected, output.GetWriteLine());
        }
    }
}