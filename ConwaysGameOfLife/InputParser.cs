using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public static class InputParser
    {
        // parses the input received 
        
        public static Universe ParseUniverse(string userInput)
        {
            var universe = SplitInput(userInput, ",");
            var gridWidth = Int32.Parse(universe[0]);
            var gridLength = Int32.Parse(universe[1]);
            return new Universe(gridWidth, gridLength);
        }

        public static Location ParseLocation(string input)
        {
            var location = SplitInput(input, ",");
            var x = Int32.Parse(location[0]);
            var y = Int32.Parse(location[1]);
            return new Location(x, y);
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }

        
    }
}