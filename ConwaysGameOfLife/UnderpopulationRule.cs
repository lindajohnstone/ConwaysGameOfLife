using System;

namespace ConwaysGameOfLife
{
    public class UnderpopulationRule : IRule
    {
        // responsible for validating underpopulation rule

        // * Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.  

        public bool ShouldSwitchCellState(int numberAliveNeighbours, CellState cellState)
        {
            return cellState == CellState.Alive && numberAliveNeighbours < 2;
        }
    }
}