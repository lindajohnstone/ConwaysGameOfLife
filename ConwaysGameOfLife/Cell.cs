using System;

namespace ConwaysGameOfLife
{
    public class Cell
    {
        // stores location & cellstate
        private CellState _cellState;

        public Cell()
        {
            _cellState = CellState.Dead;
        }

        public bool IsAlive()
        {
            return _cellState == CellState.Alive;
        }
    }
}