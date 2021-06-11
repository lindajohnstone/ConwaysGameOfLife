using System;

namespace ConwaysGameOfLife
{
    public static class OutputFormatter 
    {
        // formats universe display
        // TODO: try StringBuilder 

        public static string FormatUniverse(Universe universe) // universe created with user input - dimensions & live cells ?? - needed??
        {
            var format = "";
            for (var y = 0; y < universe.GridLength; y++)
            {
                for (var x = 0; x < universe.GridWidth; x++)
                {
                    var state = universe.GetCellAtLocation(x, y).CellState;
                    if (state == CellState.Dead)
                    {
                        format = format + ". ";
                    }
                    if (state == CellState.Alive)
                    {
                        format = format + "* ";
                    }
                }
                format = format + Environment.NewLine;
            }
            return format;
        }
    }
}