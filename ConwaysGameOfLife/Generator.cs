using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class Generator
    {
        // checks rules then creates new universe
        private List<IRule> _rules;

        private List<Cell> _cells;

        public Generator()
        {
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

        private bool ShouldSwitchCellState()
        {
            throw new NotImplementedException();
        }

        public void GenerateNewUniverse(Universe universe)
        {
            var cells = universe.Cells;
            AddCellsToList(cells);
        }

        public List<Cell> AddCellsToList(List<Cell> cells)
        {
            _cells = new List<Cell>();
            foreach (var cell in cells)
            {
                // check rules
                _cells.Add(cell);
            }
            return _cells;
        }
    }
}