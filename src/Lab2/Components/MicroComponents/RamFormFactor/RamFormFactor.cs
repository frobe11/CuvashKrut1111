namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.RamFormFactor;

public class RamFormFactor : IRamFormFactor
{
    public RamFormFactor(string info)
    {
        Info = info;
    }

    public string Info { get; }
}