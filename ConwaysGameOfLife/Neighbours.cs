using System;
using System.Collections;
using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class Neighbours
    {
        public List<Location> NeighbourLocations { get; private set; }
        public List<Cell> CellNeighbours;
        private Cell _cell;
        public Neighbours(Cell cell)
        {
            _cell = cell;
            CellNeighbours = GetCellNeighbours(cell);
            NeighbourLocations = GetNeighbourLocations(cell);
        }

        private List<Location> GetNeighbourLocations(Cell cell)
        {
            NeighbourLocations = new List<Location>();
            NeighbourLocations.Add(new Location(cell.Location.X - 1, cell.Location.Y - 1));//0,0
            NeighbourLocations.Add(new Location(cell.Location.X - 1, cell.Location.Y));// 0,1
            NeighbourLocations.Add(new Location(cell.Location.X - 1, cell.Location.Y + 1));//0,2
            NeighbourLocations.Add(new Location(cell.Location.X, cell.Location.Y - 1));//1,0
            NeighbourLocations.Add(new Location(cell.Location.X, cell.Location.Y + 1));//1,2
            NeighbourLocations.Add(new Location(cell.Location.X + 1, cell.Location.Y - 1));//2,0
            NeighbourLocations.Add(new Location(cell.Location.X + 1, cell.Location.Y));//2,1
            NeighbourLocations.Add(new Location(cell.Location.X + 1, cell.Location.Y + 1));//2,2
            return NeighbourLocations;
        }

        private List<Cell> GetCellNeighbours(Cell cell)
        {
            CellNeighbours = new List<Cell>();
            CellNeighbours.Add(new Cell(cell.CellState, cell.Location.X - 1, cell.Location.Y - 1));//0,0
            CellNeighbours.Add(new Cell(cell.CellState, cell.Location.X - 1, cell.Location.Y));// 0,1
            CellNeighbours.Add(new Cell(cell.CellState, cell.Location.X - 1, cell.Location.Y + 1));//0,2
            CellNeighbours.Add(new Cell(cell.CellState, cell.Location.X, cell.Location.Y - 1));//1,0
            CellNeighbours.Add(new Cell(cell.CellState, cell.Location.X, cell.Location.Y + 1));//1,2
            CellNeighbours.Add(new Cell(cell.CellState, cell.Location.X + 1, cell.Location.Y - 1));//2,0
            CellNeighbours.Add(new Cell(cell.CellState, cell.Location.X + 1, cell.Location.Y));//2,1
            CellNeighbours.Add(new Cell(cell.CellState, cell.Location.X + 1, cell.Location.Y + 1));//2,2
            return CellNeighbours;
        }
    }
}