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
        // if lines uncommented, both tests (line 44) fail. is this method doing too much? how to test? - does it need to be tested
        {
            _output.WriteLine(Messages.RequestDimensions);
            var input = CreateValidUniverseString();
            InputParser.ParseUniverse(input);
            // _output.WriteLine(Messages.RequestLiveCell);
            // var locationInput = _input.ReadLine();
            // var location = SetLiveCellLocation(locationInput, universe.GridWidth, universe.GridLength);
            // universe.SwitchCellState(universe.GetCellAtLocation(location.X, location.Y));
            // DisplayUniverse();
        }
        public void DisplayUniverse() 
        {
            _output.WriteLine(OutputFormatter.FormatUniverse(_universe));
        }

        public void Run()
        {
            _output.WriteLine(Messages.Welcome);
            // create 
            try
            {
                
            }
            catch (InvalidFormatException ex)
            {

            }
        }
        // TODO: method asks for universe input, validates, returns string
        // same for location

        
        public string CreateValidUniverseString()
        {
            var input = _input.ReadLine();
            var isValidUniverse = Validator.IsValidUniverse(input);
            if(!isValidUniverse)
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

        public Location SetLiveCellLocation(string input) // TODO: refactor to return string
        {
            
            var isValidLocation = Validator.IsValidLocation(input, _universe.GridWidth, _universe.GridLength);
            if (isValidLocation) return InputParser.ParseLocation(input);
            throw new InvalidFormatException(String.Format("Invalid input. Please try again." + Environment.NewLine + Messages.RequestLiveCell));
        }
    }
}
