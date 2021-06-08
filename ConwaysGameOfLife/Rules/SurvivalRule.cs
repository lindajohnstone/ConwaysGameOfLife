namespace ConwaysGameOfLife
{
    public class SurvivalRule : IRule
    {
        // responsible for validating survival rule

        // * Any live cell with two or three live neighbours lives on to the next generation.

        public bool ShouldSwitchCellState(int numberAliveNeighbours, CellState cellState)
        {
            if (cellState == CellState.Dead)
            {
                return false;
            }
            if (cellState == CellState.Alive)
            {
                if (numberAliveNeighbours == 2 || numberAliveNeighbours == 3)
                {
                    return false;
                }
            }
            return true;
        }
    }
}