using System;

namespace ConwaysGameOfLife
{
    public class GameController
    {
        // responsible for implementing game
        // orchestrator type class - brings all together

        /*
            welcome message
            user asked for universe dimensions
            dimensions parsed
            universe initialized
            initial universe printed to console
            user asked for location of alive cells
            input parsed/validated
            universe set up with live cells
            universe printed
            game plays
            rules checked
            new universe regenerated
            ends either by user typing q or all dead cells

            input
            output
            universe
            rules
        */
        private Universe _universe;

        private IInput _input;

        private IOutput _output;

        public GameController(IInput input, IOutput output)
        {
            _input = input;
            _output = output;
        }

        public void CreateInitialUniverse()
        {
            _output.WriteLine(Messages.RequestDimensions);
            var input = CreateValidUniverseString();
            _universe = InputParser.ParseUniverse(input);
        }

        public void PopulateUniverseWithLiveCells()
        {
            // _output.Write(Messages.RequestLiveCell);
            // _output.WriteLine($ or {Messages.Play});
            // loop
            // var locationInput = _input.ReadLine();
            // var location = SetLiveCellLocation(locationInput, universe.GridWidth, universe.GridLength);
            // universe.SwitchCellState(universe.GetCellAtLocation(location.X, location.Y));
            // DisplayUniverse();
            throw new NotImplementedException();
        }

        public void DisplayUniverse() 
        {
            _output.WriteLine(OutputFormatter.FormatUniverse(_universe));
        }

        public void Run()
        {
            _output.WriteLine(Messages.Welcome);
            // create initial universe
            CreateInitialUniverse();
            DisplayUniverse();
            // add live cells to universe until user presses 'p' to play
            // generator checks all cells if change of state required & creates next universe
            // loop last step until user presses 'q' to quit or all cells are dead
        }
        
        public string CreateValidUniverseString()
        {
            var input = _input.ReadLine();
            var isValidUniverse = Validator.IsValidUniverse(input);
            while (!isValidUniverse)
            {
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine(Messages.RequestDimensions);
                input = _input.ReadLine();
                isValidUniverse = Validator.IsValidUniverse(input);
            }
            return input;
        }

        public string CreateValidLocationString(int gridWidth, int gridLength)
        {
            var input = _input.ReadLine();
            var isValidLocation = Validator.IsValidLocation(input, gridWidth, gridLength);
            while (!isValidLocation) 
            {
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine($"{Messages.RequestLiveCell}.");
                input = _input.ReadLine();
                isValidLocation = Validator.IsValidLocation(input, gridWidth, gridLength);
            }
            return input;
        }
    }
}
