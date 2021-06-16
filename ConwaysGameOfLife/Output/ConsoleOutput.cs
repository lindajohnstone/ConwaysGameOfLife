using System;

namespace ConwaysGameOfLife
{
    public class ConsoleOutput : IOutput
    {
        // handles console output
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}