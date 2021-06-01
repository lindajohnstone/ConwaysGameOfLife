using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife.Tests
{
    public static class TestUniverse // TODO: move these functions into UniverseShould
    {
        public static Universe InitializeUniverse(String sourceData) //TODO: rename?
        {
            var rows = SplitInput(sourceData, Environment.NewLine);
            var gridWidth = rows[0].Length;
            var gridLength = rows.Length;
            var cells = new List<Cell>();

            for (var y = 0; y < gridLength; y++)
            {
                var row = rows[y];
                if (row.Length != gridWidth)
                {
                    throw new ArgumentOutOfRangeException("The row should be the correct width");
                }
                for (var x = 0; x < gridWidth; x++)
                {
                    var currentCell = row[x];
                    cells.Add(new Cell(GetSourceDataCellState(currentCell), x, y));
                }
            }
            return new Universe(gridWidth, gridLength, cells);
        }

        private static CellState GetSourceDataCellState(char value) // TODO: rename method and parameter
        {
            if (value == 'X')
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