using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Model;

public class JumpEngineOmegaFuelCounter : IJumpEngineFuelCounter
{
    public int Count(int distance)
    {
        return Convert.ToInt32(distance * Math.Log2(distance));
    }
}