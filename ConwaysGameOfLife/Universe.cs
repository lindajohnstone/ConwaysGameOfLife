using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class Universe
    {
        // creates the Universe/World
        private List<Cell> _cells;

        private int _gridWidth;

        private int _gridLength;

        public Universe(int gridWidth, int gridLength)
        {
            _gridWidth = gridWidth;
            _gridLength = gridLength;
            _cells = InitializeCells(gridWidth, gridLength);
        }

        private List<Cell> InitializeCells(int gridWidth, int gridLength)
        {
            var cells = new List<Cell>();
            for (var width = 0; width < gridWidth; width++)
            {
                for (var length = 0; length < gridLength; length++)
                {
                    cells.Add(new Cell(CellState.Dead, width, length));
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
    }
}