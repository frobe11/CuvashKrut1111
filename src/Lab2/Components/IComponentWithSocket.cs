using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IComponentWithSocket
{
    public ISocket Socket { get; }
}