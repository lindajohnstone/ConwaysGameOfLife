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

        public void Run()
        {
            // write welcome to console
            _output.WriteLine(Messages.Welcome);
            // ask for universe dimensions
            _output.WriteLine(Messages.RequestDimensions);
            // get input
            var input = _input.ReadLine();
            // if input is q, end game
            if (UserEndsGame(input))
            {
                _output.WriteLine(Messages.GameEnd);
                return;
            }
            // if input is not q
            // are dimensions valid
            var isValidUniverse = Validator.IsValidUniverse(input);
            while (!isValidUniverse)
            {
                // if dimensions are not valid, ask user for dimensions
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine(Messages.RequestDimensions);
                input = _input.ReadLine();
                // is input is q, game ends
                if (UserEndsGame(input))
                {
                    _output.WriteLine(Messages.GameEnd);
                    return;
                }

                isValidUniverse = Validator.IsValidUniverse(input);
            }
            // input is valid & universe is created & displayed
            _universe = InputParser.ParseUniverse(input);
            DisplayUniverse();
            // need to loop through adding location input until user enters p
            do 
            {
                // user prompted for location input
                _output.Write(Messages.RequestLiveCell);
                // or to enter p to play
                _output.WriteLine($" or {Messages.Play}");
                // receive input
                input = _input.ReadLine();
                // if input is q, end game
                if (UserEndsGame(input))
                {
                    _output.WriteLine(Messages.GameEnd);
                    return;
                }
                if (input == "p")
                {
                    Play();
                    _output.WriteLine(Messages.GameEnd);
                    return;
                }
                // is location input valid
                // is yes, move to line 109
                var isValidLocation = Validator.IsValidLocation(input, _universe.GridWidth, _universe.GridLength);
                // if no
                while (!isValidLocation)
                {
                    // user prompted for valid location input - loops until valid input received
                    _output.WriteLine(Messages.InvalidInput);
                    _output.WriteLine($"{Messages.RequestLiveCell}.");
                    input = _input.ReadLine();
                    // if input is q, game ends
                    if (UserEndsGame(input))
                    {
                        _output.WriteLine(Messages.GameEnd);
                        return;
                    }
                    
                    isValidLocation = Validator.IsValidLocation(input, _universe.GridWidth, _universe.GridLength);
                }
                // location is valid, location is parsed
                var location = InputParser.ParseLocation(input);
                // change cell state of cell at location to alive
                SetLiveCellLocation(location);
                // display universe
                DisplayUniverse();
            }
            while (input != "p");
        }

        private void Play()
        {
            while(!_universe.AreAllCellsDead())
            {
                var generator = new Generator(_universe);
                _universe = generator.GenerateNewUniverse();
                Console.Clear();
                DisplayUniverse();
            }
        }

        private bool UserEndsGame(string input)
        {
            return input == "q";
        }

        private void CreateInitialUniverse()
        {
            _output.WriteLine(Messages.RequestDimensions);
            var input = CreateValidUniverseString();
            _universe = InputParser.ParseUniverse(input);
        }

        private void DisplayUniverse()
        {
            _output.WriteLine(OutputFormatter.FormatUniverse(_universe));
        }

        // public void PopulateUniverseWithLiveCells()
        // {
        //     _output.Write(Messages.RequestLiveCell);
        //     _output.WriteLine($"or {Messages.Play}");
        //     //loop until player presses "p" to play
        //     var locationInput = CreateValidLocationString();
        //     var location = InputParser.ParseLocation(locationInput);
        //     _universe.SwitchCellState(_universe.GetCellAtLocation(location));
        // }

        private string CreateValidUniverseString()
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

        private void CreateValidLocationString(string input)
        {
            var isValidLocation = Validator.IsValidLocation(input, _universe.GridWidth, _universe.GridLength);
            while (!isValidLocation)
            {
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine($"{Messages.RequestLiveCell}.");
                input = _input.ReadLine();
                if (UserEndsGame(input))
                {
                    _output.WriteLine(Messages.GameEnd);
                    return;
                }
                isValidLocation = Validator.IsValidLocation(input, _universe.GridWidth, _universe.GridLength);
            }
        }

        private void SetLiveCellLocation(Location location)
        {
            var cell = _universe.GetCellAtLocation(location);
            cell.SwitchCellState();
        }
    }
}