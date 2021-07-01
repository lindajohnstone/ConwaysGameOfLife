using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class Generator
    {
        // checks rules then creates new universe
        private List<IRule> _rules;

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
        }
        /*
                universe
            check each cell in universe for number of live neighbours & cellstate
            & check if any rules are true
            if true, switch the state of the cell & add to new list of cells
            false, add cell to new list of cells
            regenerate universe using gridWidth, gridlength, new list of cells

        */

        public Universe GenerateNewUniverse()
        {
            var oldCells = _oldUniverse.Cells;
            var newCells = new List<Cell>();
            GenerateCells(oldCells, newCells);
            return new Universe(_oldUniverse.GridWidth, _oldUniverse.GridLength, newCells);
        }

        private List<Cell> GenerateCells(List<Cell> oldCells, List<Cell> newCells)
        {
            foreach (var cell in oldCells)
            {
                Cell newCell = GenerateNewCell(cell);
                newCells.Add(newCell);
            }
            return newCells;
        }

        private Cell GenerateNewCell(Cell cell)
        {
            var numberOfLiveNeighbours = _oldUniverse.CountLiveNeighbours(cell);
            var state = cell.CellState;

            var newCell = new Cell(state, cell.Location.X, cell.Location.Y);
            if (ShouldSwitchCellState(numberOfLiveNeighbours, state))
            {
                newCell.SwitchCellState();
            }

            return newCell;
        }

        private bool ShouldSwitchCellState(int numberOfLiveNeighbours, CellState state)
        {
            return _rules.Any((rule) => rule.ShouldSwitchCellState(numberOfLiveNeighbours, state));
        }
    }
}