using System;

namespace ConwaysGameOfLife
{
    public class Cell
    {
        // stores location & cellstate
        private CellState _cellState;

        public Location Location { get; private set; }

        public Cell(CellState state, int x, int y)
        {
            _cellState = state;
            Location = new Location(x, y);
        }

        public bool IsAlive()
        {
            return _cellState == CellState.Alive;
        }
    }
}