using System;

namespace ConwaysGameOfLife
{
    public class UnderpopulationRule : IRule
    {
        // responsible for validating underpopulation rule

        // * Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.  



        // public bool ShouldSwitchCellState(int x, int y)// TODO: pass in number of live neighbours & cellstate? if cellstate.dead return false
        // {
        //     var cell = _universe.GetCellAtLocation(x, y);
        //     if (_universe.CountLiveNeighbours(cell) < 2 && cell.CellState == CellState.Alive) return true;
        //     return false;
        // }

        public bool ShouldSwitchCellState(int numberAliveNeighbours, CellState cellState)
        {
            return cellState == CellState.Alive && numberAliveNeighbours < 2;
        }
    }
}