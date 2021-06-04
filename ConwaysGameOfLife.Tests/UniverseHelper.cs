using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife.Tests
{
    public static class UniverseHelper
    {
        public static bool UniversesAreEqual(Universe obj1, Universe obj2)
        {
            var isSizeSame = (obj1.GridWidth == obj2.GridWidth) && (obj1.GridLength == obj2.GridLength);
            if (!isSizeSame)
            {
                return false;
            }
            
            for (var x = 0; x < obj1.GridLength; x++)
            {
                for (var y = 0; y < obj1.GridLength; y++)
                {
                    var cell1 = obj1.GetCellAtLocation(x, y); 
                    var cell2 = obj2.GetCellAtLocation(x, y);
                    if (cell1 == null || cell2 == null)
                    {
                        return false;
                    }
                    if (cell1.CellState != cell2.CellState) // TODO: cellstate method similar to getcellatlocation
                    {
                        return false; 
                    }
                }
            }
            return true;
        }

        public static bool CellsAreEqual(Cell obj1, Cell obj2)
        {
            var isLocationSame = (obj1.Location.X == obj2.Location.X) && (obj1.Location.Y == obj2.Location.Y);
            var isCellStateSame = obj1.CellState == obj2.CellState;
            return isCellStateSame && isLocationSame;
        }

        public static bool ListsOfCellsAreEqual(List<Cell> obj1, List<Cell> obj2)
        {
            if (obj1.Count != obj2.Count)
            {
                return false;
            }
            var obj1Ordered = obj1.OrderBy(c => c.Location.X).ThenBy(c => c.Location.Y).ToList();
            var obj2Ordered = obj2.OrderBy(c => c.Location.X).ThenBy(c => c.Location.Y).ToList();

            for (var cell = 0; cell < obj1.Count; cell++)
            {
                if (!CellsAreEqual(obj1Ordered[cell], obj2Ordered[cell]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool LocationsAreEqual(Location obj1, Location obj2)
        {
            if (obj1.X == obj2.X && obj1.Y == obj2.Y)
            {
                return true;
            }
            return false;
        }
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