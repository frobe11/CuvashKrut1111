using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Processor.Builder;

public interface IProcessorBuilder
{
    IProcessorBuilder WithCoreFrequency(int coreFrequency);
    IProcessorBuilder WithCoreNumber(int number);
    IProcessorBuilder WithSocket(ISocket socket);
    IProcessorBuilder WithVideoCore(bool withVideoCore);
    IProcessorBuilder WithSupportedMemoryFrequencies(IEnumerable<int> frequencies);
    IProcessorBuilder WithTpd(double tdp);
    IProcessorBuilder WithPower(int power);
    IProcessor Build();
}