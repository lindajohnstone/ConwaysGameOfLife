using System;

namespace ConwaysGameOfLife.Tests
{
    public static class UniverseHelper
    {
        public static bool UniversesAreEqual(Universe obj1, Universe obj2)
        {
            var isSizeSame = (obj1.GridWidth == obj2.GridWidth) && (obj1.GridLength == obj2.GridLength);
            if (!isSizeSame)
            {
                return false;
            }
            
            for (var x = 0; x < obj1.GridLength; x++)
            {
                for (var y = 0; y < obj1.GridLength; y++)
                {
                    var cell1 = obj1.GetCellAtLocation(x, y);
                    var cell2 = obj2.GetCellAtLocation(x, y);
                    if (cell1 != cell2)
                    {
                        if (cell1.CellState != cell2.CellState) // TODO: cellstate method similar to getcellatlocation
                        {
                            return false; 
                        }
                    }
                }
            }
            return true;
        }

        public static bool CellsAreEquivalent(Cell obj1, Cell obj2)
        {
            throw new NotImplementedException();
        }
    }
}