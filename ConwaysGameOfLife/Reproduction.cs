namespace ConwaysGameOfLife
{
    public class Reproduction : IRule
    {
        // responsible for validating reproduction rule

        // * Any dead cell with exactly three live neighbours becomes a live cell.

        public bool ShouldSwitchCellState(int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}