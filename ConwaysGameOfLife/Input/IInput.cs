using System;

namespace ConwaysGameOfLife
{
    public interface IInput
    {
        // leave open for extension - file input instead of console input

        public string ReadLine();

        public bool ConsoleKeyAvailable();
        
        public ConsoleKeyInfo ReadKey(bool value);
    }
}