using System;

namespace ConwaysGameOfLife
{
    public class Validator
    {
        // validates input
        public bool IsUniverse(Universe input)
        {
            return input.GridWidth > 0 && input.GridLength > 0;
        }

        public bool IsLocation(Location input, int gridWidth, int gridLength)
        {
            return input.X < gridWidth && input.Y < gridLength && input.X >= 0 && input.Y >= 0;
        }
    }
}