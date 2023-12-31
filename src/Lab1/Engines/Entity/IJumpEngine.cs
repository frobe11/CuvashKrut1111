using Itmo.ObjectOrientedProgramming.Lab1.Engines.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entity;

public interface IJumpEngine
{
    EngineWorkResult Work(int distance);
}