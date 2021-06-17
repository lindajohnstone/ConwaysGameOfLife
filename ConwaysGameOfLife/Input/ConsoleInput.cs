using System;

namespace ConwaysGameOfLife
{
    public class ConsoleInput : IInput
    {
        // handles console input
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}