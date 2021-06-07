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

        public bool AreAllCellsDead() 
        {
            return Cells.All((cell) => !cell.IsAlive());
        }

        public List<Location> GetCellNeighbourLocations(Cell cell)
        {
            var x = cell.Location.X;
            var y = cell.Location.Y;
            var xLeft = x == 0 ? GridWidth - 1 : x - 1;
            var xRight = x == GridWidth - 1  ? 0 : x + 1;
            var yTop = y == 0 ? GridLength - 1 : y - 1;
            var yBottom = y == GridLength - 1 ? 0 : y + 1;
            var neighbourLocations = new List<Location>() {
                new Location(xLeft, yTop),     
                new Location(xLeft, y),         
                new Location(xLeft, yBottom),     
                new Location(x, yTop),         
                new Location(x, yBottom),         
                new Location(xRight, yTop),     
                new Location(xRight, y),         
                new Location(xRight, yBottom)      
            };
            
            return neighbourLocations;
        }

        public int CountLiveNeighbours(Cell cell)
        {
            var aliveNeighbours = new List<Location>();
            ThrowsExceptionIfObjectIsNull(cell); // TODO: check if cell is null before calling
            var neighbourLocations = GetCellNeighbourLocations(cell);
            foreach (var neighbour in neighbourLocations)
            {
                var state = GetCellAtLocation(neighbour.X, neighbour.Y).CellState;
                if (state == CellState.Alive)
                {
                    aliveNeighbours.Add(neighbour);
                }
            }
            return aliveNeighbours.Count;
        }

        private static void ThrowsExceptionIfObjectIsNull(Object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException();
            }
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