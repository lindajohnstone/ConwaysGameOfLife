using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class InputParser
    {
        // parses the input received 
        public List<Location> ParseListOfLocationsFromUserInput(string userInput)
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