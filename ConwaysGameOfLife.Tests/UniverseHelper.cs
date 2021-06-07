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
            
            for (var x = 0; x < universe1.GridLength; x++)
            {
                for (var y = 0; y < universe1.GridLength; y++)
                {
                    var cell1 = universe1.GetCellAtLocation(x, y); 
                    var cell2 = universe2.GetCellAtLocation(x, y);
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

        public static bool ListsOfLocationsAreEqual(List<Location> location1, List<Location> location2)
        {
            if (location1.Count != location2.Count)
            {
                return false;
            }
            var location1Ordered = location1.OrderBy(c => c.X).ThenBy(c => c.Y).ToList();
            var location2Ordered = location2.OrderBy(c => c.X).ThenBy(c => c.Y).ToList();

            for (var location = 0; location < location1.Count; location++)
            {
                if (!LocationsAreEqual(location1Ordered[location], location2Ordered[location]))
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