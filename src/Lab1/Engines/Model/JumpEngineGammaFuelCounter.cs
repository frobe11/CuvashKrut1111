using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Model;

public class JumpEngineGammaFuelCounter : IJumpEngineFuelCounter
{
    public int Count(int distance)
    {
        return Convert.ToInt32(Math.Pow(distance, 2));
    }
}