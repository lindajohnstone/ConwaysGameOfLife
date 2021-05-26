using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife.Tests
{
    public class StubOutput : IOutput
    {
        List<string> _outputList;

        public StubOutput()
        {
            _outputList = new List<string>();
        }
        public void ConsoleWrite(string value)
        {
            _outputList.Add(value);
        }

        public void ConsoleWriteLine(string value)
        {
            _outputList.Add(value);
        }

        public string GetWriteLine()
        {
            return String.Join("", _outputList);
        }

        public string GetWriteLine(int i)
        {
            return _outputList[i];
        }
    }
}