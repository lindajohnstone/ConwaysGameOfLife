using System.Collections.Generic;

namespace ConwaysGameOfLife.Tests
{
    public static class SourceData
    {
        public static Universe UniverseInitializedAllDeadCells()
        {
            var initData = new CellState[][]
            {
                // initData.Add(new Cell(CellState.Dead, 0, 0));
                // initData.Add(new Cell(CellState.Dead, 0, 1));
                // initData.Add(new Cell(CellState.Dead, 0, 2));
                // initData.Add(new Cell(CellState.Dead, 1, 0));
                // initData.Add(new Cell(CellState.Dead, 1, 1));
                // initData.Add(new Cell(CellState.Dead, 1, 2));
                // initData.Add(new Cell(CellState.Dead, 2, 0));
                // initData.Add(new Cell(CellState.Dead, 2, 1));
                // initData.Add(new Cell(CellState.Dead, 2, 2))

                new[] { CellState.Dead, CellState.Dead, CellState.Dead },
                new []  {CellState.Dead,   CellState.Dead,    CellState.Dead },
                new []  {CellState.Dead,   CellState.Dead,    CellState.Dead }
            };
            return new Universe(initData);
        }
    }
}