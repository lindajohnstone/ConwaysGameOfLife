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

        public override bool Equals(object obj)
        {
            return obj is Location location &&
                   X == location.X &&
                   Y == location.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool OperatorOverride(Location obj1, Location obj2)
        {
            if ((object)obj1 == null && (object)obj2 == null)
            {
                return true;
            }
            if ((object)obj1 == null || (object)obj2 == null)
            {
                return false;
            }
            if (obj1.X == obj2.X && obj1.Y == obj2.Y)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(Location obj1, Location obj2)
        {
            if (OperatorOverride(obj1, obj2))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Location obj1, Location obj2)
        {
            if (!OperatorOverride(obj1, obj2))
            {
                return false;
            }
            return true;
        }
    }
}