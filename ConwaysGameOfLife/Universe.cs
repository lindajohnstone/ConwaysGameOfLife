using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class Universe
    {
        // creates the Universe/World
        private List<Cell> _cells;
        private List<Location> _neighbourLocations;
        public List<Location> AllLocations { get => _cells.Select(cell => cell.Location).ToList(); }
        public int GridWidth { get; private set; }
        public int GridLength { get; private set; }

        public Universe(int gridWidth, int gridLength)
        {
            Initialize(gridWidth, gridLength, InitializeCells(gridWidth, gridLength));
        }

        // public Universe(String sourceData)
        // {
        //     TestUniverse.;
        // }
        public Universe(Universe sourceUniverse)
        {
            Initialize(sourceUniverse.GridWidth, sourceUniverse.GridLength, sourceUniverse._cells);
        }
        
        public void Initialize(int gridWidth, int gridLength, List<Cell> cells)
        {
            GridWidth = gridWidth;
            GridLength = gridLength;
            _cells = cells;
        }
        
        private List<Cell> InitializeCells(CellState[][] sourceData)
        {
            var gridWidth = sourceData.GetLength(0);
            var gridLength = sourceData.Length;
            var _cells = new List<Cell>();
            for (var x = 0; x < gridWidth; x++)
            {
                if (sourceData[x].Length != gridWidth)
                {
                    throw new ArgumentOutOfRangeException("sourceData should be a square array");
                }
                for (var y = 0; y < gridLength; y++)
                {
                    if (sourceData[y].Length != gridLength)
                    {
                        throw new ArgumentOutOfRangeException("sourceData should be a square array");
                    }
                    _cells.Add(new Cell(sourceData[x][y], x, y));
                }
            }
            return _cells;
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

        public CellState GetCellStateFromLocation(Location location)
        {
            var newCells = _cells.Where(cell => cell.Location == new Location(cell.Location.X, cell.Location.Y));
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

            }
            return neighbourList;
        }

        public Cell SwitchCellState(Cell cell)
        {
            if (cell.IsAlive())
            {
                return new Cell(CellState.Dead, cell.Location.X, cell.Location.Y);
            }
            return new Cell(CellState.Alive, cell.Location.X, cell.Location.Y);
        }
    }
}