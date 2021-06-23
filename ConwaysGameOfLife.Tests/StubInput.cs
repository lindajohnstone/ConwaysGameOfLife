using System.Collections.Generic;

namespace ConwaysGameOfLife.Tests
{
    public class StubInput : IInput
    {
        private Queue<string> _queue;

        public StubInput()
        {
            _queue = new Queue<string>();
        }      

        public string ReadLine()
        {
            return _queue.Dequeue();
        }
        
        public void GetReadLine(string value)
        {
            _queue.Enqueue(value);
        }

        public void GetReadLine(IEnumerable<string> values)
        {
            foreach (var value in values)
            {
                GetReadLine(value);
            }
        }
    }
}