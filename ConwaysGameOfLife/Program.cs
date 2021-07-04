using System;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new ConsoleInput();
            var output = new ConsoleOutput();
            var controller = new GameController(input, output);
            controller.Run();
        }
    }
}
