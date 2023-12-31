using System;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IComponent : IEquatable<IComponent>
{
     CheckCompatibilityResult СheckСompatibility(IComponent component);
}