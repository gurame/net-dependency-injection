namespace MultiFunction.ConsoleApp.Console;

public class ConsoleWriter : IConsoleWriter
{
    public void Write(string message)
    {
        System.Console.WriteLine(message);
    }
}
