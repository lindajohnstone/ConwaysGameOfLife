using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class Universe
    {
        // creates the Universe/World
        private List<Cell> _cells;
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

        public int HowManyLiveNeighbours(Cell cell, Neighbours neighbours)
        {
            return 0;
            //neighbours.CellNeighbours.Count((x) => x.CellState == CellState.Alive);
        }
    }
}