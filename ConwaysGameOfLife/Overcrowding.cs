namespace ConwaysGameOfLife
{
    public class Overcrowding : IRule
    {
        // responsible for validating overcrowding rule

        // * Any live cell with more than three live neighbours dies, as if by overcrowding.

        public bool ShouldSwitchCellState(int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}