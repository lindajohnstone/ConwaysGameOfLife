using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class UniverseShould
    {
        [Fact]
        public void WhenInitialized_BePopulatedWithAllDeadCells() 
        {
            var gridWidth = 4;
            var gridLength = 4;
            var universe = new Universe(gridWidth, gridLength);

            var result = universe.AreAllCellsDead();
            
            Assert.True(result);
        }  

        [Fact]
        public void WhenInitialized_UniverseSizeIsCorrect()
        {
            var gridWidth = 4;
            var gridLength = 4;
            var universe = new Universe(gridWidth, gridLength);

            var result = universe.GetSize();

            Assert.Equal(16, result);
        } 

        [Fact]
        public void WhenUniverseGenerated_ReturnsNumberOfLiveNeighbours()
        {
            var universe = new Universe(3, 3);
            var cell = new Cell(CellState.Dead, 1, 1);
            var neighbours = new Neighbours(cell);
            var expected = 8;
            var cell1 = new Cell(CellState.Alive, 0, 0);
            var cell2 = new Cell(CellState.Alive, 0, 1);
            var cell3 = new Cell(CellState.Alive, 0, 2);
            var cell4 = new Cell(CellState.Alive, 1, 0);
            var cell5 = new Cell(CellState.Alive, 1, 2);
            var cell6 = new Cell(CellState.Alive, 2, 0);
            var cell7 = new Cell(CellState.Alive, 2, 1);
            var cell8 = new Cell(CellState.Alive, 2, 2);

            var result = universe.HowManyLiveNeighbours(cell, neighbours);

            Assert.Equal(expected, result);
        }
    }
}