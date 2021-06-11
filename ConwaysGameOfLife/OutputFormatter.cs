using System;
using System.Text;

namespace ConwaysGameOfLife
{
    public static class OutputFormatter 
    {
        // formats universe display 

        public static string FormatUniverse(Universe universe) // universe created with user input - dimensions & live cells ?? - needed??
        {
            StringBuilder format = new StringBuilder();
            for (var y = 0; y < universe.GridLength; y++)
            {
                for (var x = 0; x < universe.GridWidth; x++)
                {
                    var state = universe.GetCellAtLocation(x, y).CellState;
                    if (state == CellState.Dead)
                    {
                        format.Append("💀");
                    }
                    if (state == CellState.Alive)
                    {
                        format.Append("💟");
                    }
                }
                format.Append(Environment.NewLine);
            }
            return format.ToString();
        }
    }
}