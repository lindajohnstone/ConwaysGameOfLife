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
            inputparser
            outputformatter
        */
        Universe _universe;
        IOutput _output;


        public Generator(Universe universe)
        {
            _universe = universe;
            _output = new ConsoleOutput();
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