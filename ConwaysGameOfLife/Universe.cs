using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class Universe
    {
        // creates the Universe/World
        private List<Cell> _cells;
        public List<Location> AllLocations { get => _cells.Select(cell => cell.Location).ToList(); }
        public int GridWidth { get; private set; }
        public int GridLength { get; private set; }

        public Universe(int gridWidth, int gridLength)
        {
            GridWidth = gridWidth;
            GridLength = gridLength;
            _cells = InitializeCells(gridWidth, gridLength);
        }

        private List<Cell> InitializeCells(int gridWidth, int gridLength)
        {
            var cells = new List<Cell>();
            for (var x = 0; x < gridWidth; x++)
            {
                for (var y = 0; y < gridLength; y++)
                {
                    cells.Add(new Cell(CellState.Dead, x, y));
                }
            }
            return cells;
        }

        public int GetSize()
        {
            return _cells.Count;
        }

        public bool AreAllCellsDead() 
        {
            return _cells.All((cell) => !cell.IsAlive());
        }

        public List<Location> GetCellNeighbourLocations(Cell cell)
        {
            var neighbourLocations = new List<Location>();
            neighbourLocations.Add(new Location(cell.Location.X - 1, cell.Location.Y - 1));//0,0
            neighbourLocations.Add(new Location(cell.Location.X - 1, cell.Location.Y));// 0,1
            neighbourLocations.Add(new Location(cell.Location.X - 1, cell.Location.Y + 1));//0,2
            neighbourLocations.Add(new Location(cell.Location.X, cell.Location.Y - 1));//1,0
            neighbourLocations.Add(new Location(cell.Location.X, cell.Location.Y + 1));//1,2
            neighbourLocations.Add(new Location(cell.Location.X + 1, cell.Location.Y - 1));//2,0
            neighbourLocations.Add(new Location(cell.Location.X + 1, cell.Location.Y));//2,1
            neighbourLocations.Add(new Location(cell.Location.X + 1, cell.Location.Y + 1));//2,2
            return neighbourLocations;
        }

        public CellState GetCellStateFromLocation(Cell cell)
        {
            var newCells = _cells.Where(cell => cell.Location == new Location(cell.Location.X, cell.Location.Y));
            var newCell = newCells.ElementAt(0);
            return newCell.CellState;
        }
    }
}