using System;
using System.Text;

namespace ConwaysGameOfLife
{
    public static class OutputFormatter 
    {
        // formats universe display 
        /*
            x = column, y = row
            x,y so 1,2 would be
            💀💀💀
            💀💀💀
            💀💟💀

            and 2,0 would be
            💀💀💟
            💀💀💀
            💀💀💀
        */

        public static string FormatUniverse(Universe universe) 
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (var y = 0; y < universe.GridLength; y++)
            {
                for (var x = 0; x < universe.GridWidth; x++)
                {
                    var location = new Location(x, y); 
                    var state = universe.GetCellAtLocation(location).CellState;
                    if (state == CellState.Dead)
                    {
                        stringBuilder.Append("💀");
                    }
                    if (state == CellState.Alive)
                    {
                        stringBuilder.Append("💟");
                    }
                }
                stringBuilder.Append(Environment.NewLine);
            }
            return stringBuilder.ToString();
        }
    }
}