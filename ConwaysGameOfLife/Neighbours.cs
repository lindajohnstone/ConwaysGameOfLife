using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class Neighbours
    {
        public List<Cell> CellNeighbours { get; private set; }
        private Cell _cell;
        public Neighbours(Cell cell)
        {
            _cell = cell;
            CellNeighbours = InitializeCellNeighbours(cell);
        }

        private List<Cell> InitializeCellNeighbours(Cell cell)
        {
            CellNeighbours = new List<Cell>();
            CellNeighbours.Add(new Cell(CellState.Dead, cell.Location.X - 1, cell.Location.Y - 1));//0,0
            CellNeighbours.Add(new Cell(CellState.Dead, cell.Location.X - 1, cell.Location.Y));// 0,1
            CellNeighbours.Add(new Cell(CellState.Dead, cell.Location.X - 1, cell.Location.Y + 1));//0,2
            CellNeighbours.Add(new Cell(CellState.Dead, cell.Location.X, cell.Location.Y - 1));//1,0
            CellNeighbours.Add(new Cell(CellState.Dead, cell.Location.X, cell.Location.Y + 1));//1,2
            CellNeighbours.Add(new Cell(CellState.Dead, cell.Location.X + 1, cell.Location.Y - 1));//2,0
            CellNeighbours.Add(new Cell(CellState.Dead, cell.Location.X + 1, cell.Location.Y));//2,1
            CellNeighbours.Add(new Cell(CellState.Dead, cell.Location.X + 1, cell.Location.Y + 1));//2,2
            return CellNeighbours;
        }

        

        // public static bool OperatorOverride(Neighbours obj1, Neighbours obj2)
        // {
        //     if ((object)obj1 == null && (object)obj2 == null)
        //     {
        //         return true;
        //     }
        //     if ((object)obj1 == null || (object)obj2 == null)
        //     {
        //         return false;
        //     }
        //     if (obj1 == obj2 && obj1 == obj2)
        //     {
        //         return true;
        //     }
        //     return false;
        // }

        // public static bool operator ==(Neighbours obj1, Neighbours obj2)
        // {
        //     if (OperatorOverride(obj1, obj2))
        //     {
        //         return true;
        //     }
        //     return false;
        // }

        // public static bool operator !=(Neighbours obj1, Neighbours obj2)
        // {
        //     if (!OperatorOverride(obj1, obj2))
        //     {
        //         return false;
        //     }
        //     return true;
        // }
    }
}