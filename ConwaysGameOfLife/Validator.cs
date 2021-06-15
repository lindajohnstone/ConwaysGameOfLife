using System;

namespace ConwaysGameOfLife
{
    public class Validator
    {
        // validates input

        public static bool ParseInput(string numberInput)
        {
            if (Int32.TryParse(numberInput, out var number))
            {
                return true;
            }
            return false;
        }
        
        public bool IsValidUniverse(string input)
        {
            // check there's 1 comma exactly
            // check that the two dimensions are able to be parsed to int
            // check that the parsed integer dimensions are both > 0
            if (!input.Contains(",")) return false;
            if (input.Length > 3) return false;
            var isValid = SplitInput(input, ",");
            if (isValid.Length != 2) return false;
            if (!ParseInput(isValid[0]) || !ParseInput(isValid[1])) return false;
            if (Int32.Parse(isValid[0]) <= 0) return false;
            return true;
        }

        public bool IsLocation(Location input, int gridWidth, int gridLength)
        {
            return input.X < gridWidth && input.Y < gridLength;
        }
        private static void ThrowException(int x, int y)
        {
            if (x < 0 || y < 0) throw new ArgumentException("String should only contain numbers greater than or equal to 0.");
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}