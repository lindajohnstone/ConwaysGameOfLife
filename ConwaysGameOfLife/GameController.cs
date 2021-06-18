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

        private IOutput _output;

        private IInput _input;

        public GameController(Universe universe, IOutput output, IInput input)
        {
            _universe = universe;
            _output = output;
            _input = input;
        }

        public void CreateInitialUniverse()
        {
            _output.WriteLine(Messages.RequestDimensions);
            var input = CreateValidUniverseString();
            InputParser.ParseUniverse(input);
            DisplayUniverse();
        }

        public void PopulateUniverseWithLiveCells()
        {
            // _output.Write(Messages.RequestLiveCell);
            // _output.WriteLine($"Or {Messages.Play});
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
                InvalidUniverseString(input);
            }
            return input;
        }

        private void InvalidUniverseString(string input)
        {
            _output.WriteLine($"Invalid input. Please try again.{Environment.NewLine}{Messages.RequestDimensions}");
            CreateValidUniverseString();
        }

        public string CreateValidLocationString()
        {
            var input = _input.ReadLine();
            var isValidLocation = Validator.IsValidLocation(input, _universe.GridWidth, _universe.GridLength);
            while (!isValidLocation) 
            {
                InvalidLocationString(input);
            }
            return input;
        }

        private void InvalidLocationString(string input)
        {
            _output.WriteLine($"Invalid input. Please try again.{Environment.NewLine}{Messages.RequestLiveCell}");
            CreateValidLocationString();
        }
    }
}
