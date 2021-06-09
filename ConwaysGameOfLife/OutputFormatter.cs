using System;

namespace ConwaysGameOfLife
{
    public class OutputFormatter 
    {
        // displays universe & instructions
        // TODO: try StringBuilder 
        public string FormatInitialUniverse(Universe universe)
        {
            var format = "";
            for (var x = 0; x < universe.GridWidth; x++)
            {
                for (var y = 0; y < universe.GridLength; y++)
                {
                    format = format + ". ";
                }
                format = format + Environment.NewLine;
            }
            return format;
        }

        public string FormatUniverse(Universe universe) // universe created with user input - dimensions & live cells ?? - needed??
        {
            var format = "";
            for (var x = 0; x < universe.GridWidth; x++)
            {
                for (var y = 0; y < universe.GridLength; y++)
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