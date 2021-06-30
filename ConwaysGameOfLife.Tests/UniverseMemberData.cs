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

        public static TheoryData<string[], string[]> UniversesFromStrings =
            new TheoryData<string[], string[]>
        {
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
            },
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
            },
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
            },
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
            },
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
            },
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
            },
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
            },
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
            },
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
            }
        };
    }
}