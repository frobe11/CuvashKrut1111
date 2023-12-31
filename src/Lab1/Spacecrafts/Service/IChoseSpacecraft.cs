using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Service;

public interface IChoseSpacecraft
{
    ISpacecraft? Choose(IEnumerable<GoThroughTheRoteResult> spacecraftResults);
}