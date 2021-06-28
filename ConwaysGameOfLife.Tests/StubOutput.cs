using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife.Tests
{
    public class StubOutput : IOutput
    {
        public List<string> OutputList { get; private set; } = new List<string>();

        public void Write(string value)
        {
            OutputList.Add(value);
        }

        public void WriteLine(string value)
        {
            OutputList.Add(value);
        }

        public string GetWriteLine()
        {
            return String.Join("", OutputList);
        }

        public string GetWriteLine(int i)
        {
            return OutputList[i];
        }

        public string GetLastWriteLine()
        {
            return OutputList.LastOrDefault();
        }
    }
}