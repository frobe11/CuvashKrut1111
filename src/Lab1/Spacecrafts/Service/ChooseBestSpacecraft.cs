using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Service;

public class ChooseBestSpacecraft : IChoseSpacecraft
{
    public ISpacecraft? Choose(IEnumerable<GoThroughTheRoteResult> spacecraftResults)
    {
        ISpacecraft? bestSpacecraft = null;
        int bestPrice = int.MaxValue;
        foreach (GoThroughTheRoteResult result in spacecraftResults)
        {
            if (result is not GoThroughTheRoteResult.Success success) continue;
            if (bestPrice <= success.FuelPrice) continue;
            bestSpacecraft = success.Spacecraft;
            bestPrice = success.FuelPrice;
        }

        return bestSpacecraft;
    }
}