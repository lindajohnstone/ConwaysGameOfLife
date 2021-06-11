using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class InputParser
    {
        // parses the input received 

        public Universe ParseUniverse(string userInput)
        {
            var universe = SplitInput(userInput, ",");
            var gridWidth = ParseInput(universe[0]);
            var gridLength = ParseInput(universe[1]);
            ThrowException(gridWidth, gridLength, 1);
            return new Universe(ParseInput(universe[0]), ParseInput(universe[1]));
        }

        public Location ParseLocation(string input)
        {
            var location = SplitInput(input, ",");
            var x = ParseInput(location[0]);
            var y = ParseInput(location[1]);
            ThrowException(x, y, 0);
            return new Location(x, y);
        }

        private static void ThrowException(int x, int y, int minimum)
        {
            var message = String.Format($"String should only contain numbers greater than or equal to {0}.", minimum);
            if (x < 0 || y < 0) throw new ArgumentException(message);
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }

        private static int ParseInput(string numberInput)
        {
            if(Int32.TryParse(numberInput, out var number))
            {
                return number;
            }
            return -1;
        }
    }
}