namespace Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Model;

public class SpecialFuelExchange : IExchange
{
    private const int PriceForSpecialFuel = 20;
    public int Count(IFuelUsage fuelUsage)
    {
        return PriceForSpecialFuel * fuelUsage.Quantity;
    }
}