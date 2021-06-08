using System;

namespace ConwaysGameOfLife
{
    public class Underpopulation : IRules
    {
        // responsible for validating underpopulation rule
        
        // * Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.  
        
        private Universe _universe;
        public Underpopulation(Universe universe)
        {
            _universe = universe;
        }

        public bool Check(int x, int y)
        {
            var cell = _universe.GetCellAtLocation(x, y);
            if (_universe.CountLiveNeighbours(cell) < 2 && cell.CellState == CellState.Alive) return true;
            return false;
        }
    }
}