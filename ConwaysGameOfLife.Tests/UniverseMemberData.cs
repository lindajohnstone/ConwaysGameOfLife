using System.Collections.Generic;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public static class UniverseMemberData
    {
        public static TheoryData<Cell> CellsInUniverse =
            new TheoryData<Cell>
            {
                new Cell(CellState.Dead, 0, 0),
                new Cell(CellState.Dead, 0, 1),
                new Cell(CellState.Dead, 0, 2),
                new Cell(CellState.Dead, 1, 0),
                new Cell(CellState.Dead, 1, 1),
                new Cell(CellState.Dead, 1, 2),
                new Cell(CellState.Dead, 2, 0),
                new Cell(CellState.Dead, 2, 1),
                new Cell(CellState.Dead, 2, 2)
            };

        public static TheoryData<string[]> UniversesFromStrings =
            new TheoryData<string[]> 
        // TODO: fails. 
        // error: System.InvalidOperationException : The test method expected 2 parameter values, but 1 parameter value was provided.
            {
                new string[]
                {
                    "OXX",
                    "OXX",
                    "OXX"
                },
                new string[]
                {
                    "OOO",
                    "OOO",
                    "OOO"
                }
            };

        public static IEnumerable<object[]> GetUniverseFromDataGenerator()
        {
            yield return new object[]
            {
                new string[]
                {
                    "OXX",
                    "OXX",
                    "OXX"
                },
                new string[]
                {
                    "OOO",
                    "OOO",
                    "OOO"
                }
            };
            yield return new object[]
            {
                new string[]
                {
                    "OXXXX",
                    "OXXXX",
                    "OXXXX"
                },
                new string[]
                {
                    "OOXXO",
                    "OOXXO",
                    "OOXXO"
                }
            };
            yield return new object[]
            {
                new string[]
                {
                    "OOO",
                    "OOX",
                    "OXX"
                },
                new string[]
                {
                    "XXX",
                    "XXX",
                    "XXX"
                }
            };
            yield return new object[]
            {
                new string[]
                {
                    "XXX",
                    "OXX",
                    "OXX"
                },
                new string[]
                {
                    "XXX",
                    "XXX",
                    "XXX"
                }
            };
            yield return new object[]
            {
                new string[]
                {
                    "XXX",
                    "OOX",
                    "OXX"
                },
                new string[]
                {
                    "OOO",
                    "OOO",
                    "OOO"
                }
            };
        }
    }
}