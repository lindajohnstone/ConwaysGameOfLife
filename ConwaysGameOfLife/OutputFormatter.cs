using System;

namespace ConwaysGameOfLife
{
    public class OutputFormatter
    {
        // displays universe & instructions
        public string FormatInitialUniverse(Universe universe)
        {
            var format = "";
            for (var x = 0; x < universe.GridWidth; x++)
            {
                for (var y = 0; y < universe.GridLength; y++)
                {
                    format = format + ". ";
                }
                format = format + Environment.NewLine;
            }
            return format;
        }

        public string FormatWelcomeMessage()
        {
            return "Welcome to Game of Life!";
        }

        public string FormatUniverse() // universe created with user input - dimensions & live cells ?? - needed??
        {
            throw new NotImplementedException();
        }

        // print method to ask user for universe dimensions

        // print press q to quit

        // print end message
    }
}