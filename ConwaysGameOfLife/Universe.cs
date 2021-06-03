using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class Universe
    {
        // creates the Universe/World
        public List<Cell> Cells { get; private set; }
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

        public CellState GetCellStateFromLocation(Location location) //TODO: do I need this - can use get cellaatlocation
        {
            // var newCell = Cells.Find(cell => cell.Location == new Location(cell.Location.X, cell.Location.Y));
            var x = location.X;
            var y = location.Y;
            var cellAtLocation = Cells.FirstOrDefault(cell => cell.Location.X == x && cell.Location.Y == y);
            return cellAtLocation.CellState;
        }

        public int CountLiveNeighbours(Cell cell) 
        {
            var aliveNeighbours = new List<Location>();
            var neighbourLocations = GetCellNeighbourLocations(cell);
            foreach (var neighbour in neighbourLocations)
            {
                var state = GetCellStateFromLocation(neighbour);
                if (state == CellState.Alive)
                {
                    aliveNeighbours.Add(neighbour);
                }
            }
            return aliveNeighbours.Count;
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

        public Cell GetCellAtLocation(int x, int y)
        {
            return Cells.FirstOrDefault(cell => cell.Location.X == x && cell.Location.Y == y);
        }
    }
}