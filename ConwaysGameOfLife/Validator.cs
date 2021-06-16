using System;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class Validator
    {
        // validates input

        public bool IsValidUniverse(string input)
        {
            var inputElements = SplitInput(input, ",");
            var count = input.Count(_ => _ == ',');
            var containsComma = input.Contains(",");
            var hasTwoElements = inputElements.Length == 2;
            
            if (count > 1) return false;
            if (!Int32.TryParse(inputElements[0], out var _) || Int32.Parse(inputElements[0]) <= 0) return false;
            if (!Int32.TryParse(inputElements[1], out var _) || Int32.Parse(inputElements[1]) <= 0) return false;
            return containsComma && hasTwoElements;
        }

        public bool IsValidLocation(string input, int gridWidth, int gridLength)
        {
            var inputElements = SplitInput(input, ",");
            var count = input.Count(_ => _ == ',');
            var containsComma = input.Contains(",");
            if (!containsComma) return false;
            var xIsValid = Int32.TryParse(inputElements[0], out var x) && x >= 0 && x < gridWidth;
            var yIsValid = Int32.TryParse(inputElements[1], out var y) && y >= 0 && y < gridLength;

            if (count > 1) return false;
            
            return xIsValid && yIsValid;
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}