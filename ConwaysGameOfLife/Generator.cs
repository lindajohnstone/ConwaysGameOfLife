using System;

namespace ConwaysGameOfLife
{
    public class Generator
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
        public Universe Universe { get; set; }
        
        IOutput _output;

        IInput _input; 
        public Generator(Universe universe, IOutput output, IInput input)
        {
            Universe = universe;
            _output = output;
            _input = input;
        }

        public void GenerateUniverse()
        // if lines uncommented, both tests (line 44) fail. is this method doing too much? how to test? - does it need to be tested
        {
            _output.WriteLine(Messages.RequestDimensions);
            var universeInput = _input.ReadLine();
            var universe = SetUniverseDimensions(universeInput);
            // _output.WriteLine(Messages.RequestLiveCell);
            // var locationInput = _input.ReadLine();
            // var location = SetLiveCellLocation(locationInput, universe.GridWidth, universe.GridLength);
            // universe.SwitchCellState(universe.GetCellAtLocation(location.X, location.Y));
            // DisplayUniverse();
        }
        public void DisplayUniverse() 
        {
            _output.WriteLine(OutputFormatter.FormatUniverse(Universe));
        }

        public void Run()
        {
            _output.WriteLine(Messages.Welcome);

            try
            {
                
            }
            catch (InvalidFormatException ex)
            {

            }
        }

        public Universe SetUniverseDimensions(string input)
        {
            var isValidUniverse = Validator.IsValidUniverse(input);
            if (isValidUniverse) return InputParser.ParseUniverse(input);
            throw new InvalidFormatException(String.Format("Invalid input. Please try again." + Environment.NewLine + Messages.RequestDimensions));
        }

        public Location SetLiveCellLocation(string input, int gridWidth, int gridLength)
        {
            
            var isValidLocation = Validator.IsValidLocation(input, Universe.GridWidth, Universe.GridLength);
            if (isValidLocation) return InputParser.ParseLocation(input);
            throw new InvalidFormatException(String.Format("Invalid input. Please try again." + Environment.NewLine + Messages.RequestLiveCell));
        }
    }
}
