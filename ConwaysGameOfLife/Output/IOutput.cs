namespace ConwaysGameOfLife
{
    public interface IOutput
    {
        // leave open for extension - other output instead of console output - write file (save game?)
        public void ConsoleWriteLine(string value);
        public void ConsoleWrite(string value);
    }
}