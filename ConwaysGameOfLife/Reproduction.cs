namespace ConwaysGameOfLife
{
    public class Reproduction : IRule
    {
        // responsible for validating reproduction rule

        // * Any dead cell with exactly three live neighbours becomes a live cell.

        public bool ShouldSwitchCellState(int numberAliveNeighbours, CellState cellState)
        {
            throw new System.NotImplementedException();
        }
    }
}