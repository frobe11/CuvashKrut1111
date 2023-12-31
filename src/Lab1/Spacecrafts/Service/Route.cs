using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Service;

public class Route
{
    private ICollection<IEnvironment> _environments;

    public Route(ICollection<IEnvironment> environments)
    {
        _environments = environments;
    }

    public void AddPartOfTheWay(IEnvironment environment)
    {
        _environments.Add(environment);
    }

    public GoThroughTheRoteResult GoThroughTheRote(ISpacecraft spacecraft)
    {
        int time = 0;
        var defaultFuelExchange = new DefaultFuelExchange();
        var specialFuelExchange = new SpecialFuelExchange();
        var defaultFuelUsage = new DefaultFuelUsage();
        var specialFuelUsage = new SpecialFuelUsage();
        foreach (IEnvironment environment in _environments)
        {
            EnterWithResult result = environment.EnterWith(spacecraft);
            switch (result)
            {
                case EnterWithResult.CrewDied:
                    return new GoThroughTheRoteResult.CrewDied();
                case EnterWithResult.SpacecraftDestroyed:
                    return new GoThroughTheRoteResult.SpacecraftDestroyed();
                case EnterWithResult.SpacecraftLost:
                    return new GoThroughTheRoteResult.SpacecraftLost();
                case EnterWithResult.Success success:
                    time += success.Time;
                    defaultFuelUsage.Quantity += success.DefaultFuelUsage.Quantity;
                    specialFuelUsage.Quantity += success.SpecialFuelUsage.Quantity;
                    break;
            }
        }

        return new GoThroughTheRoteResult.Success(time, specialFuelExchange.Count(specialFuelUsage) + defaultFuelExchange.Count(defaultFuelUsage), spacecraft);
    }
}