using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class GeneratorShould
    {
        Generator _generator;
        public GeneratorShould()
        {
            _generator = new Generator();
        }
        [Fact]
        public void WhenInitialized_DisplayUniverse()
        {
            var output = new StubOutput();
            var formatter = new OutputFormatter();
            var expected = ". . . \n. . . \n. . . \n";

            _generator.DisplayUniverse(output, formatter);

            Assert.Equal(expected, output.GetWriteLine());
        }
    }
}