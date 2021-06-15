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
            var isNumber = SplitInput(input, ",");
            return !input.Contains(",") && input.Length > 3 
                && isNumber.Length != 2 && !ParseInput(isNumber[0]) 
                && !ParseInput(isNumber[1]) && Int32.Parse(isNumber[0]) <= 0;
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