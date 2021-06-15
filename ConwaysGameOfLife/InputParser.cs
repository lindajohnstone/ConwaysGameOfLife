using System;

namespace ConwaysGameOfLife
{
    public static class InputParser
    {
        // parses the input received 
        public static Universe ParseUniverse(string userInput)
        {
            var dimensions = SplitInput(userInput, ",");
            var gridWidth = Int32.Parse(dimensions[0]);
            var gridLength = Int32.Parse(dimensions[1]);
            return new Universe(gridWidth, gridLength);
        }

        public static Location ParseLocation(string input)
        {
            var coordinates = SplitInput(input, ",");
            var x = Int32.Parse(coordinates[0]);
            var y = Int32.Parse(coordinates[1]);
            return new Location(x, y);
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}