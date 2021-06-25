using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class Cell
    {
        // stores location & cellstate
        public CellState CellState { get; private set; }

        public Location Location { get; private set; }

        public Cell(CellState state, int x, int y)
        {
            CellState = state;
            Location = new Location(x, y);
        }

        public bool IsAlive()
        {
            return CellState == CellState.Alive;
        }

        public void SwitchCellState()
        {
            CellState = IsAlive() ? CellState.Dead : CellState.Alive;
        }
    }
}