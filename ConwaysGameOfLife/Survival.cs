namespace ConwaysGameOfLife
{
    public class Survival : IRule
    {
        // responsible for validating survival rule

        // * Any live cell with two or three live neighbours lives on to the next generation.

        public bool ShouldSwitchCellState(int numberAliveNeighbours, CellState cellState)
        {
            throw new System.NotImplementedException();
        }
    }
}