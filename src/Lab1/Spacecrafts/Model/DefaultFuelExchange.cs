namespace Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Model;

public class DefaultFuelExchange : IExchange
{
    private const int PriceForBaseFuel = 5;
    public int Count(IFuelUsage fuelUsage)
    {
        return PriceForBaseFuel * fuelUsage.Quantity;
    }
}