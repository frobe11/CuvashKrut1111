using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IComponentWithSupportedSockets
{
    IEnumerable<ISocket> SupportedSockets { get; }
}