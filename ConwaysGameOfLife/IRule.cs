namespace ConwaysGameOfLife
{
    public interface IRule
    {
        public bool ShouldSwitchCellState(int numberAliveNeighbours, CellState cellState);
    }
}