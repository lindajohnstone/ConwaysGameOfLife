using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class Universe
    {
        // creates the Universe/World
        public List<Cell> Cells { get; private set; }
        private List<Location> _neighbourLocations;
        public List<Location> AllLocations { get => Cells.Select(cell => cell.Location).ToList(); } // TODO: refactor to replace this logic
        public int GridWidth { get; private set; }
        public int GridLength { get; private set; }

        public Universe(int gridWidth, int gridLength)
        {
            Initialize(gridWidth, gridLength, InitializeCells(gridWidth, gridLength));
        }

        public Universe(int gridWidth, int gridLength, List<Cell> cells)
        {
            Initialize(gridWidth, gridLength, cells);
        }
        
        private void Initialize(int gridWidth, int gridLength, List<Cell> cells)
        {
            GridWidth = gridWidth;
            GridLength = gridLength;
            Cells = cells;
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
            return Cells.Count;
        }

        public bool AreAllCellsDead() 
        {
            return Cells.All((cell) => !cell.IsAlive());
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

        public CellState GetCellStateFromLocation(Location location)
        {
            var newCells = Cells.Where(cell => cell.Location == new Location(cell.Location.X, cell.Location.Y));
            var newCell = newCells.ElementAt(0);
            return newCell.CellState;
        }

        public List<Cell> CheckIfNeighboursAlive(Cell cell) 
        {
            var neighbourList = new List<Cell>();
            _neighbourLocations = GetCellNeighbourLocations(cell);
            foreach (var neighbour in _neighbourLocations)
            {
                var state = GetCellStateFromLocation(neighbour);
                if (state == CellState.Alive)
                {
                    _neighbourLocations.Add(neighbour);
                }
            }
            return neighbourList;
        }

        public Cell SwitchCellState(Cell cell) // changes the state of the cell // TODO: rename. 
        // NB should universe check state of cell & neighbours against the rules then create a new universe?
        {
            if (cell.IsAlive())
            {
                return new Cell(CellState.Dead, cell.Location.X, cell.Location.Y);
            }
            return new Cell(CellState.Alive, cell.Location.X, cell.Location.Y);
        }

        public override bool Equals(object obj)
        {
            return obj is Universe universe &&
                   EqualityComparer<List<Cell>>.Default.Equals(Cells, universe.Cells) &&
                   EqualityComparer<List<Location>>.Default.Equals(_neighbourLocations, universe._neighbourLocations) &&
                   EqualityComparer<List<Location>>.Default.Equals(AllLocations, universe.AllLocations) &&
                   GridWidth == universe.GridWidth &&
                   GridLength == universe.GridLength;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Cells, _neighbourLocations, AllLocations, GridWidth, GridLength);
        }
    }
}