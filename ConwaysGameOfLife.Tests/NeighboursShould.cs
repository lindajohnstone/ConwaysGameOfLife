using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class NeighboursShould
    {
        [Fact]
        public void WhenGivenANonBoundaryCell_ReturnCorrectNeighbours()
        {
            var universe = new Universe(3, 3);
            var cell = new Cell(CellState.Dead, 1, 1);
            var neighbours = new Neighbours(cell);
            var expected = new List<Cell>(){
                new Cell(CellState.Dead, 0, 0),
                new Cell(CellState.Dead, 0, 1),
                new Cell(CellState.Dead, 0, 2),
                new Cell(CellState.Dead, 1, 0),
                new Cell(CellState.Dead, 1, 2),
                new Cell(CellState.Dead, 2, 0),
                new Cell(CellState.Dead, 2, 1),
                new Cell(CellState.Dead, 2, 2)
            };

            var result = neighbours.CellNeighbours;
            
            Assert.True(UniverseHelper.ListsOfCellsAreEqual(expected, result));
            //Assert.All(result, ac => expected.Contains(ec => UniverseHelper.CellsAreEqual(cell, ac))); 
        }

        [Fact]
        public void WhenGivenANonBoundaryCell_ReturnCorrectNeighbourLocations()
        {
            var universe = new Universe(3, 3);
            var cell = new Cell(CellState.Dead, 1, 1);
            var neighbours = new Neighbours(cell);
            var expected = new List<Location>();
            expected.Add(new Location(0, 0));
            expected.Add(new Location(0, 1));
            expected.Add(new Location(0, 2));
            expected.Add(new Location(1, 0));
            expected.Add(new Location(1, 2));
            expected.Add(new Location(2, 0));
            expected.Add(new Location(2, 1));
            expected.Add(new Location(2, 2));

            var result = neighbours.NeighbourLocations;

            Assert.Equal(expected, result);
        }
    }
}