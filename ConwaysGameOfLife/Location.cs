using System;

namespace ConwaysGameOfLife
{
    public class Location
    {
        // stores pair of coords - X, Y

        public int X { get; set; }

        public int Y { get; set; }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}