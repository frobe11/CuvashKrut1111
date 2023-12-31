namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IDirector<T>
{
    T Direct(T builder);
}