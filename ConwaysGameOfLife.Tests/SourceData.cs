namespace ConwaysGameOfLife.Tests
{
    public static class SourceData
    {
        public static Universe UniverseInitializedAllDeadCells()
        {
            var initData = new CellState[][]
            {
                new []  {CellState.Dead,   CellState.Dead,    CellState.Dead },
                new []  {CellState.Dead,   CellState.Dead,    CellState.Dead },
                new []  {CellState.Dead,   CellState.Dead,    CellState.Dead }
            };
            return new Universe(initData);
        }
    }
}