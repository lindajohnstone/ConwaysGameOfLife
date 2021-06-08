namespace ConwaysGameOfLife
{
    public class ReproductionRule : IRule
    {
        // responsible for validating reproduction rule

        // * Any dead cell with exactly three live neighbours becomes a live cell.

        public bool ShouldSwitchCellState(int numberAliveNeighbours, CellState cellState)
        {
            return cellState == CellState.Dead && numberAliveNeighbours == 3;
        }
    }
}