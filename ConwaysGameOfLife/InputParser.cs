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
            var gridWidth = ParseInput(universe[0]);
            var gridLength = ParseInput(universe[1]);
            ThrowException(gridWidth, gridLength);
            return new Universe(ParseInput(universe[0]), ParseInput(universe[1]));
        }

        public static Location ParseLocation(string input)
        {
            var location = SplitInput(input, ",");
            var x = ParseInput(location[0]);
            var y = ParseInput(location[1]);
            ThrowException(x, y);
            return new Location(x, y);
        }

        private static void ThrowException(int x, int y)
        {
            var message = String.Format("String should only contain numbers greater than or equal to 0.");
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