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
            if (!input.Contains(",")) return false;
            if (input.Length > 3) return false;
            if (isNumber.Length != 2) return false;
            if (!ParseInput(isNumber[0]) || !ParseInput(isNumber[1])) return false;
            if (Int32.Parse(isNumber[0]) <= 0) return false;
            return true;
        }

        public bool IsValidLocation(string input, int gridWidth, int gridLength)
        {
            var isNumber = SplitInput(input, ","); 
            if (!input.Contains(",")) return false;
            if (input.Length > 3) return false;
            if (isNumber.Length != 2) return false;
            if (!ParseInput(isNumber[0])) return false;
            if (!ParseInput(isNumber[1])) return false;
            if (Int32.Parse(isNumber[0]) < 0) return false;
            if (Int32.Parse(isNumber[1]) < 0) return false;
            if (Int32.Parse(isNumber[0]) >= gridWidth) return false;
            if (Int32.Parse(isNumber[1]) >= gridLength) return false;
            return true;
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}