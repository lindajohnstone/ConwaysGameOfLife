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

        public Cell SwitchCellState(Cell cell) // changes the state of the cell
        {
            if (cell.IsAlive())
            {
                return new Cell(CellState.Dead, cell.Location.X, cell.Location.Y);
            }
            return new Cell(CellState.Alive, cell.Location.X, cell.Location.Y);
        }

        public bool IsAlive()
        {
            return CellState == CellState.Alive;
        }

        public override bool Equals(object obj)
        {
            return obj is Cell cell &&
                   CellState == cell.CellState &&
                   EqualityComparer<Location>.Default.Equals(Location, cell.Location);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CellState, Location);
        }
    }
}