namespace Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Model;

public class SpecialFuelUsage : IFuelUsage
{
    public SpecialFuelUsage()
    {
        Quantity = 0;
    }

    public int Quantity { get; set; }
}