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
            
            if (UserEndsGame(input)) return;

            var isValidUniverse = Validator.IsValidUniverse(input);
            while (!isValidUniverse)
            {
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine(Messages.RequestDimensions);
                input = _input.ReadLine();
                isValidUniverse = Validator.IsValidUniverse(input);
            }
            _universe = InputParser.ParseUniverse(input);
            //CreateInitialUniverse(input);
            DisplayUniverse();
            input = _input.ReadLine();

            if (UserEndsGame(input)) return;

            _output.Write(Messages.RequestLiveCell);
            _output.WriteLine($"or {Messages.Play}");
            var locationInput = CreateValidLocationString(input);
            var location = InputParser.ParseLocation(locationInput);
            var cell = _universe.GetCellAtLocation(location);
            cell.SwitchCellState();
            DisplayUniverse();

            input = _input.ReadLine();

            if (UserEndsGame(input)) return;
            // add live cells to universe until user presses 'p' to play
            // PopulateUniverseWithLiveCells();
            // DisplayUniverse();
            // generator checks all cells if change of state required & creates next universe
            // loop last step until user presses 'q' to quit or all cells are dead
        }

        private bool UserEndsGame(string input)
        {
            if (input == "q")
            {
                return true;
            }
            return false;
        }

        public void CreateInitialUniverse(string input)
        {
            _output.WriteLine(Messages.RequestDimensions);
            input = CreateValidUniverseString();
            _universe = InputParser.ParseUniverse(input);
        }

        public void DisplayUniverse()
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

        public string CreateValidLocationString(string input)
        {
            var isValidLocation = Validator.IsValidLocation(input, _universe.GridWidth, _universe.GridLength);
            while (!isValidLocation) 
            {
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine($"{Messages.RequestLiveCell}.");
                input = _input.ReadLine();
                isValidLocation = Validator.IsValidLocation(input, _universe.GridWidth, _universe.GridLength);
            }
            return input;
        }

        public Universe ReturnUniverseAfterSettingLiveCellLocation(Location location)
        {
            var cell = _universe.GetCellAtLocation(location); 
            cell.SwitchCellState();
            return _universe;
        }
    }
}
