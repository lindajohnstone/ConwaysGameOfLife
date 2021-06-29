using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class Generator
    {
        // checks rules then creates new universe
        private List<IRule> _rules;

        private List<Cell> _cells;

        private Universe _oldUniverse;

        public Generator(Universe universe)
        {
            _oldUniverse = universe;
            _rules = new List<IRule>()
                        {
                new OvercrowdingRule(),
                new ReproductionRule(),
                new SurvivalRule(),
                new UnderpopulationRule()
                        };

            _cells = new List<Cell>();
        }
        /*
                universe
            check each cell in universe for number of live neighbours & cellstate
            & check if any rules are true
            if true, switch the state of the cell & add to new list of cells
            false, add cell to new list of cells
            regenerate universe using gridWidth, gridlength, new list of cells

        */

        private bool ShouldSwitchCellState(Cell cell)
        {
            /*
                need number of neighbours, cell state 
                return _rules.Any(_ => _.ShouldSwitchCellState(numberOfLiveNeighbours, cellstate));
            */
            throw new NotImplementedException();
        }

        public Universe GenerateNewUniverse()
        {
            var oldCells = _oldUniverse.Cells;
            var newCells = new List<Cell>();
            foreach (var cell in oldCells)
            {
                var numberOfLiveNeighbours = _oldUniverse.CountLiveNeighbours(cell);
                var state = cell.CellState;

                var newCell = new Cell(state, cell.Location.X, cell.Location.Y);
                var shouldNewCellHaveDifferentCellState = _rules.Any((rule) => rule.ShouldSwitchCellState(numberOfLiveNeighbours, state));
                if (shouldNewCellHaveDifferentCellState)
                {
                    newCell.SwitchCellState();
                }
                newCells.Add(newCell);
            }

            // GenerateCells(cells);
            return new Universe(_oldUniverse.GridWidth, _oldUniverse.GridLength, newCells);
        }

        public Cell GenerateNewCell(Cell cell)
        {
            var generatedCell = new Cell(cell.CellState, cell.Location.X, cell.Location.Y);
            return generatedCell;
        }

        public List<Cell> GenerateCells(List<Cell> cells)
        {
            foreach (var cell in cells)
            {
                // check rules
                _cells.Add(cell);
            }
            return _cells;
        }
    }
}