namespace Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Model;

public class DefaultFuelUsage : IFuelUsage
{
    public DefaultFuelUsage()
    {
        Quantity = 0;
    }

    public int Quantity { get; set; }
}