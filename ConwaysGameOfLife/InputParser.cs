using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class InputParser
    {
        // parses the input received 
        public List<Location> ParseLocations(string userInput)
        {
            var liveCellLocations = new List<Location>();
            var locationStringArray = SplitInput(userInput, " ");
            for (var i = 0; i < locationStringArray.Length; i++)
            {
                var location = SplitInput(locationStringArray[i], ",");

                liveCellLocations.Add(new Location(ParseInput(location[0]), ParseInput(location[1])));
            }
            return liveCellLocations;
        }

        public Universe ParseUniverse(string userInput)
        {
            var universe = SplitInput(userInput, ",");
            return new Universe(ParseInput(universe[0]), ParseInput(universe[1]));
        }

        public Location ParseLocation(string input)
        {
            var location = SplitInput(input, ",");
            return new Location(ParseInput(location[0]), ParseInput(location[1]));
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