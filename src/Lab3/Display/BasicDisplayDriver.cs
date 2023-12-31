using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public class BasicDisplayDriver : IDisplayDriver
{
    private Color _color;

    public BasicDisplayDriver()
    {
        _color = Color.White;
    }

    public void Clear()
    {
        Console.Clear();
    }

    public void WithColor(Color color)
    {
        _color = color;
    }

    public void Display(string text)
    {
        Console.WriteLine(Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(text));
    }
}