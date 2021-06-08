using System;

namespace ConwaysGameOfLife
{
    public class OutputFormatter
    {
        // displays universe & instructions
        public string FormatInitialUniverse(Universe universe)
        {
            var format = "";
            for (var x = 0; x < universe.GridWidth; x++)
            {
                for (var y = 0; y < universe.GridLength; y++)
                {
                    format = format + ". ";
                }
                format = format + Environment.NewLine;
            }
            return format;
        }

        public string FormatWelcomeMessage()
        {
            return "Welcome to Game of Life!";
        }

        public string FormatUniverse(Universe universe) // universe created with user input - dimensions & live cells ?? - needed??
        {
            var format = "";
            for (var x = 0; x < universe.GridWidth; x++)
            {
                for (var y = 0; y < universe.GridLength; y++)
                {
                    var state = universe.GetCellAtLocation(x, y).CellState;
                    if (state == CellState.Dead)
                    {
                        format = format + ". ";
                    }
                    if (state == CellState.Alive)
                    {
                        format = format + "* ";
                    }
                }
                format = format + Environment.NewLine;
            }
            return format;
        }

        public string FormatRequestForDimensions()
        {
            return "Please enter the width & length for the Universe as a number followed by a comma then a number (e.g. '0,0')";
        }

        public string FormatEndGameMessage()
        {
            return "Game of Life has ended.";
        }

        public string FormatQForQuit()
        {
            return "Enter 'q' to quit Game.";
        }
    }
}