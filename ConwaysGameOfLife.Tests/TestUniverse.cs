using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife.Tests
{
    public static class TestUniverse
    {
        public static List<Cell> InitializeUniverse(String sourceData)
        {
            var src = sourceData.Split("\n", StringSplitOptions.RemoveEmptyEntries);
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
                    _cells.Add(new Cell(GetSourceDataCellState(src[x]), x, y));
                }
            }
            return _cells;
        }

        private static CellState GetSourceDataCellState(String value)
        {
            if (value == "X")
            {
                return CellState.Dead;
            }
            return CellState.Alive;
        }
    }
}