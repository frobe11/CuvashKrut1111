using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public interface IDisplay
{
    void WithColor(Color color);
    void Display(string text);
}