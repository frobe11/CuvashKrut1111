using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public interface IRepository<T>
    where T : IComponent
{
    IRepository<T> Add(string name, T component);
    T GetComponent(string name);
}