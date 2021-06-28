using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class Generator
    {
        // checks rules then creates new universe
        List<IRule> _rules;

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

        public bool ShouldSwitchCellState()
        {
            throw new NotImplementedException();
        }
        public Universe GenerateNewUniverse(Universe universe)
        {
            throw new NotImplementedException();
        }
    }
}