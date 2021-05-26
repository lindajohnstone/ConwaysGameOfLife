using System;
using System.Collections.Generic;

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

        public override bool Equals(object obj)
        {
            return obj is Cell cell &&
                   _cellState == cell._cellState &&
                   EqualityComparer<Location>.Default.Equals(Location, cell.Location);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_cellState, Location);
        }
    }
}