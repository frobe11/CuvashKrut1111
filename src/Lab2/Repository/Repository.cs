using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class Repository<T>
    : IRepository<T>
    where T : IComponent
{
    private readonly Dictionary<string, T> _data;
    public Repository()
    {
        _data = new Dictionary<string, T>();
    }

    public IRepository<T> Add(string name, T component)
    {
        _data.Add(name, component);
        return this;
    }

    public T GetComponent(string name)
    {
        return _data[name];
    }
}