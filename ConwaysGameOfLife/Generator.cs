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

        public object EndGame(string userInput)
        {
            throw new NotImplementedException();
        }

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
    }
}
