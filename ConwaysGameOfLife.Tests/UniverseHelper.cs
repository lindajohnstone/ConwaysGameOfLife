namespace ConwaysGameOfLife.Tests
{
    public static class UniverseHelper
    {
        public static bool UniverseContentsAreEqual(Universe obj1, Universe obj2)
        {
            var isSizeSame = (obj1.GridWidth == obj2.GridWidth) && (obj1.GridLength == obj2.GridLength);
            if (!isSizeSame)
            {
                return false;
            }
            // test location using new method - for loop using index
            for (var x = 0; x < obj1.GridLength; x++)
            {
                for (var y = 0; y < obj1.GridLength; y++)
                {
                    if (obj1.GetCellAtLocation(x, y) != obj2.GetCellAtLocation(x, y))
                    {
                        if (obj1.GetCellAtLocation(x, y).CellState != obj2.GetCellAtLocation(x, y).CellState)
                        {
                            return false; 
                        }
                    }
                }
            }
            return true;
        }
    }
}