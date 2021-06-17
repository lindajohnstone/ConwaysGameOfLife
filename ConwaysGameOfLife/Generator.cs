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
        Universe _universe;

        IOutput _output;

        IInput _input; 
        public Generator(Universe universe, IOutput output, IInput input)
        {
            _universe = universe;
            _output = output;
            _input = input;
        }

        public void DisplayUniverse() 
        {
            _output.WriteLine(OutputFormatter.FormatUniverse(_universe));
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

        public Universe SetUniverseDimensions(string userInput)
        {
            var isValidUniverse = Validator.IsValidUniverse(userInput);
            if (isValidUniverse) return InputParser.ParseUniverse(userInput);
            throw new InvalidFormatException(String.Format("Invalid input. Please try again." + Environment.NewLine + Messages.RequestDimensions));
        }

        public Location SetLiveCellLocation(string input)
        {
            var isValidLocation = Validator.IsValidLocation(input, _universe.GridWidth, _universe.GridLength);
            if (isValidLocation) return InputParser.ParseLocation(input);
            throw new InvalidFormatException(String.Format("Invalid input. Please try again." + Environment.NewLine + Messages.RequestLiveCells));
        }
    }
}
