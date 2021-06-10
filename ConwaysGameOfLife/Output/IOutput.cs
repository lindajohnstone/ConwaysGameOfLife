namespace ConwaysGameOfLife
{
    public interface IOutput
    {
        // leave open for extension - other output instead of console output - write file (save game?)
        public void Write(string value);

        public void WriteLine(string value);
    }
}