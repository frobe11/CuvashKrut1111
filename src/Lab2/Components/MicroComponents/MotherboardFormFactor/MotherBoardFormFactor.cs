namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.MotherboardFormFactor;

public class MotherBoardFormFactor : IMotherBoardFormFactor
{
    public MotherBoardFormFactor(string info)
    {
        Info = info;
    }

    public string Info { get; }

    protected bool Equals(IMotherBoardFormFactor other)
    {
        return Info == other.Info;
    }
}