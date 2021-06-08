using System;

namespace ConwaysGameOfLife
{
    public class Underpopulation : IRules
    {
        // responsible for validating rules
        // should this be an interface?
        // * Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.  
        // * Any live cell with more than three live neighbours dies, as if by overcrowding.
        // * Any live cell with two or three live neighbours lives on to the next generation.
        // * Any dead cell with exactly three live neighbours becomes a live cell.
        private Universe _universe;
        public Underpopulation(Universe universe)
        {
            _universe = universe;
        }

        public bool Check(int x, int y)
        {
            if (_universe.CountLiveNeighbours(_universe.GetCellAtLocation(x, y)) < 2) return true;
            return false;
        }
    }
}