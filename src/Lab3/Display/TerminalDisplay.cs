using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public class TerminalDisplay : IDisplay
{
    private IDisplayDriver _displayDriver;

    public TerminalDisplay(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void WithColor(Color color)
    {
        _displayDriver.WithColor(color);
    }

    public void Display(string text)
    {
        _displayDriver.Clear();
        _displayDriver.Display(text);
    }
}