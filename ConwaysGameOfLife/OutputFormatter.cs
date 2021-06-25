using System;
using System.Text;

namespace ConwaysGameOfLife
{
    public static class OutputFormatter 
    {
        // formats universe display 

        public static string FormatUniverse(Universe universe) // universe created with user input - dimensions & live cells ?? - needed??
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (var y = 0; y < universe.GridLength; y++)// TODO: problem here?? - should width be first loop?
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