namespace TestProject.Mock;

public class TestableConsole
{
    private readonly string _output;

    public TestableConsole(string output)
    {
        _output = output;
    }

    public string ReadLine()
    {
        return _output;
    }
}