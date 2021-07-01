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
            _output.WriteLine(Messages.Welcome);
            _output.WriteLine(Messages.RequestDimensions);
            var input = _input.ReadLine();
            do
            {
                while (!_input.ConsoleKeyAvailable())
                {
                    // if (UserEndsGame(input))
                    // {
                    //     _output.WriteLine(Messages.GameEnd);
                    //     return;
                    // }

                    var isValidUniverse = Validator.IsValidUniverse(input);
                    while (!isValidUniverse)
                    {
                        _output.WriteLine(Messages.InvalidInput);
                        _output.WriteLine(Messages.RequestDimensions);
                        input = _input.ReadLine();
                        // if (UserEndsGame(input))
                        // {
                        //     _output.WriteLine(Messages.GameEnd);
                        //     return;
                        // }
                        isValidUniverse = Validator.IsValidUniverse(input);
                    }
                    _universe = InputParser.ParseUniverse(input);
                    DisplayUniverse();

                    do
                    {
                        _output.Write(Messages.RequestLiveCell);
                        _output.WriteLine($"or {Messages.Play}");

                        input = _input.ReadLine();

                        // if (UserEndsGame(input))
                        // {
                        //     _output.WriteLine(Messages.GameEnd);
                        //     return;
                        // }

                        var isValidLocation = Validator.IsValidLocation(input, _universe.GridWidth, _universe.GridLength);
                        while (!isValidLocation)
                        {
                            _output.WriteLine(Messages.InvalidInput);
                            _output.WriteLine($"{Messages.RequestLiveCell}.");
                            input = _input.ReadLine();

                            // if (UserEndsGame(input))
                            // {
                            //     _output.WriteLine(Messages.GameEnd);
                            //     return;
                            // }
                            isValidLocation = Validator.IsValidLocation(input, _universe.GridWidth, _universe.GridLength);
                        }
                        var location = InputParser.ParseLocation(input);

                        SetLiveCellLocation(location);
                        DisplayUniverse();
                    }
                    while (input != "p");
                    Play();
                }
            }
                while (_input.ReadKey(true).Key != ConsoleKey.Q);
        }

        private void Play()
        {
            //var generator = new Generator();

            // loop until all cells are dead or user enters q
            var generator = new Generator(_universe);
            generator.GenerateNewUniverse();

            /*
                Generator called to check rules & create new universe while game has not ended
                loop last step until user presses 'q' to quit or all cells are dead
            */
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