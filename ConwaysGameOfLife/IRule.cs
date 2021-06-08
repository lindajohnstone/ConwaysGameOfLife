namespace ConwaysGameOfLife
{
    public interface IRule
    {
        public bool ShouldSwitchCellState(int x, int y);
    }
}