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
            return !input.Contains(",") 
                && input.Length > 3 
                && isNumber.Length != 2 
                && !ParseInput(isNumber[0]) 
                && !ParseInput(isNumber[1]) 
                && Int32.Parse(isNumber[0]) <= 0;
        }

        public bool IsValidLocation(string input, int gridWidth, int gridLength)
        {
            // check if exactly 1 comma
            // check that the two dimensions are able to be parsed to int 
            // check that the parsed integer dimensions are both >= 0 
            // check that split[0] < gridwidth && split[1] < gridlength 
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