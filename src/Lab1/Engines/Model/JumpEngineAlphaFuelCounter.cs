namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Model;

public class JumpEngineAlphaFuelCounter : IJumpEngineFuelCounter
{
    public int Count(int distance)
    {
        return distance;
    }
}