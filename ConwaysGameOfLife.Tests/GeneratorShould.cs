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
        public void WhenInitialized_DisplayUniverse()
        {
            var output = new StubOutput();
            var expected = ". . . \n. . . \n. . . \n";

            _generator.DisplayUniverse(output);

            Assert.Equal(expected, output.GetWriteLine());
        }
    }
}