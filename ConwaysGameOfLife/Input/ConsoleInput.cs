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

        public bool ConsoleKeyAvailable()
        {
            return Console.KeyAvailable;
        }

        public ConsoleKeyInfo ReadKey(bool value)
        {
            return Console.ReadKey(value);
        }
    }
}