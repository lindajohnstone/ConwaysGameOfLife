using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife.Tests
{
    public static class UniverseHelper
    {
        public static bool UniversesAreEqual(Universe universe1, Universe universe2)
        {
            var isSizeSame = (universe1.GridWidth == universe2.GridWidth) && (universe1.GridLength == universe2.GridLength);
            if (!isSizeSame)
            {
                return false;
            }
            
            for (var x = 0; x < universe1.GridWidth; x++)
            {
                for (var y = 0; y < universe1.GridLength; y++)
                {
                    var location = new Location(x, y);
                    var cell1 = universe1.GetCellAtLocation(location); 
                    var cell2 = universe2.GetCellAtLocation(location);
                    if (cell1 == null || cell2 == null)
                    {
                        return false;
                    }
                    if (cell1.CellState != cell2.CellState) 
                    {
                        return false; 
                    }
                }
            }
            return true;
        }

        public static bool CellsAreEqual(Cell cell1, Cell cell2)
        {
            var isLocationSame = (cell1.Location.X == cell2.Location.X) && (cell1.Location.Y == cell2.Location.Y);
            var isCellStateSame = cell1.CellState == cell2.CellState;
            return isCellStateSame && isLocationSame;
        }

        public static bool ListsOfLocationsAreEqual(List<Location> locations1, List<Location> locations2)
        {
            if (locations1.Count != locations2.Count)
            {
                return false;
            }
            var location1Ordered = locations1.OrderBy(c => c.X).ThenBy(c => c.Y).ToList();
            var location2Ordered = locations2.OrderBy(c => c.X).ThenBy(c => c.Y).ToList();

            for (var i = 0; i < locations1.Count; i++)
            {
                if (!LocationsAreEqual(location1Ordered[i], location2Ordered[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool LocationsAreEqual(Location location1, Location location2)
        {
            if (location1.X == location2.X && location1.Y == location2.Y)
            {
                return true;
            }
            return false;
        }
        public static Universe InitializeUniverse(String sourceData)  // TODO: possibly change to taking params string[] instead 
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
                    var cellState = GetCellState(currentCell);
                    cells.Add(new Cell(cellState, x, y));
                }
            }
            return new Universe(gridWidth, gridLength, cells);
        }

        private static CellState GetCellState(char input) 
        {
            return input == 'O' ? CellState.Alive : CellState.Dead;
        }
        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}