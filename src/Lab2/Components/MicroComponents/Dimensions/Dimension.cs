namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Dimensions;

public class Dimension : IDimension
{
    public Dimension(string info)
    {
        Info = info;
    }

    public string Info { get; }
}