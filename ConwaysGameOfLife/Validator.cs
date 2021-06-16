using System;

namespace ConwaysGameOfLife
{
    public class Validator
    {
        // validates input

        public bool IsValidUniverse(string input)
        {
            var inputElements = input.Split(',');
            var hasTwoElements = inputElements.Length == 2;
            if (!hasTwoElements) return false;
            
            var gridWidthIsValid = Int32.TryParse(inputElements[0], out var gridWidth) && gridWidth > 0;
            var gridLengthIsValid = Int32.TryParse(inputElements[1], out var gridLength) && gridLength > 0;
            return gridWidthIsValid && gridLengthIsValid;
        }

        public bool IsValidLocation(string input, int gridWidth, int gridLength)
        {
            var inputElements = input.Split(',');
            var hasTwoInputElements = inputElements.Length == 2;
            if (!hasTwoInputElements) return false;

            var xIsValid = Int32.TryParse(inputElements[0], out var x) && x >= 0 && x < gridWidth;
            var yIsValid = Int32.TryParse(inputElements[1], out var y) && y >= 0 && y < gridLength;
            return xIsValid && yIsValid;
        }
    }
}