using System;

namespace ConwaysGameOfLife
{
    public class Cell
    {
        // stores location & cellstate
        private CellState _cellState;

        private Location Location { get; set; }

        public Cell(CellState state)
        {
            _cellState = state;
        }

        public bool IsAlive()
        {
            return _cellState == CellState.Alive;
        }

        public Location SetLocation(int x, int y)
        {
            return new Location(x, y);
        }
    }
}