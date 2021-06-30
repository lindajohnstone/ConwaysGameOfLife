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
            yield return new object[]
            {
                new string[]
                {
                    "XXXX",
                    "XOOX",
                    "XOOX",
                    "XXXX"
                },
                new string[]
                {
                    "XXXX",
                    "XOOX",
                    "XOOX",
                    "XXXX"
                }
            };
            yield return new object[]
            {
                new string[]
                {
                    "XXXXXX",
                    "XXOOXX",
                    "XOXXOX",
                    "XXOOXX",
                    "XXXXXX"
                },
                new string[]
                {
                    "XXXXXX",
                    "XXOOXX",
                    "XOXXOX",
                    "XXOOXX",
                    "XXXXXX"
                }
            };
            yield return new object[]
            {
                new string[]
                {
                    "XXXXXX",
                    "XXXXXX",
                    "XXOOOX",
                    "XOOOXX",
                    "XXXXXX",
                    "XXXXXX"
                },
                new string[]
                {
                    "XXXXXX",
                    "XXXOXX",
                    "XOXXOX",
                    "XOXXOX",
                    "XXOXXX",
                    "XXXXXX"
                }
            };
            yield return new object[]
            {
                new string[]
                {
                    "XXXXX",
                    "XXXXX",
                    "XOOOX",
                    "XXXXX",
                    "XXXXX"
                },
                new string[]
                {
                    "XXXXX",
                    "XXOXX",
                    "XXOXX",
                    "XXOXX",
                    "XXXXX"
                }
            };
        }
    }
}