using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife.Tests
{
    public static class TestUniverse
    {
        
    
        public static Universe InitializeUniverse(String sourceData)
        {
            var src = SplitInput(sourceData, "\n");
            var gridWidth = src[0].Length;
            var gridLength = src.Length;
            var _cells = new List<Cell>();
            // use the row/column in array to add to cell

            for (var y = 0; y < gridLength; y++)
            {
                if (src[y].Length != gridLength)
                {
                    throw new ArgumentOutOfRangeException("sourceData should be a square array"); // TODO: ?? need exception? - if yes, change message
                }
                for (var x = 0; x < gridWidth; x++)
                {
                    if (src[x].Length != gridWidth)
                    {
                        throw new ArgumentOutOfRangeException("sourceData should be a square array"); // TODO: ?? need exception? - if yes, change message
                    }
                    // split into characters
                    var currentCell = src[y][x];
                    _cells.Add(new Cell(GetSourceDataCellState(currentCell.ToString()), x, y));
                }
            }
            return new Universe(gridWidth, gridLength);
        }
        //TODO: another method to return list of cells ??
        private static CellState GetSourceDataCellState(String value)
        {
            if (value == "X")
            {
                return CellState.Dead;
            }
            return CellState.Alive;
        }
        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}