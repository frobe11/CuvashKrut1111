using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public interface IDisplayDriver
{
    void Clear();
    void WithColor(Color color);
    void Display(string text);
}