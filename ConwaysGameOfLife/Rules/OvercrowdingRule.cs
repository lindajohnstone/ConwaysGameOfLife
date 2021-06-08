namespace ConwaysGameOfLife
{
    public class OvercrowdingRule : IRule
    {
        // responsible for validating overcrowding rule

        // * Any live cell with more than three live neighbours dies, as if by overcrowding.

        public bool ShouldSwitchCellState(int numberAliveNeighbours, CellState cellState)
        {
            return cellState == CellState.Alive && numberAliveNeighbours > 3;
        }
    }
}