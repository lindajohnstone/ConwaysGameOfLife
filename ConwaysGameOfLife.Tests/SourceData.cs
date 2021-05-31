using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife.Tests
{
    public static class SourceData
    {
        public static Universe UniverseInitializedAllDeadCells()
        {
            var initData = "XXX" + Environment.NewLine + "XXX" + Environment.NewLine + "XXX";
            return new Universe(initData);
        }
    }
}