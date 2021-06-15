using System;

namespace ConwaysGameOfLife
{
    public class Validator
    {
        // validates input

        public static int ParseInput(string numberInput)
        {
            if (Int32.TryParse(numberInput, out var number))
            {
                return number;
            }
            return -1;
        }
        
        public bool IsUniverse(Universe input)
        {
            return input.GridWidth > 0 && input.GridLength > 0;
        }

        public bool IsLocation(Location input, int gridWidth, int gridLength)
        {
            return input.X < gridWidth && input.Y < gridLength;
        }
        private static void ThrowException(int x, int y)
        {
            if (x < 0 || y < 0) throw new ArgumentException("String should only contain numbers greater than or equal to 0.");
        }
    }
}