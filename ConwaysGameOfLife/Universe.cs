using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class Universe
    {
        // creates the Universe/World
        public List<Cell> Cells { get; set; }

        private int _gridWidth;

        private int _gridLength;

        public Universe(int gridWidth, int gridLength)
        {
            _gridWidth = gridWidth;
            _gridLength = gridLength;
            Cells = InitializeCells(gridWidth, gridLength);
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
    }
}