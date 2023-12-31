using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Socket;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Processor.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Processor;

public class Processor : IProcessor, IDirector<IProcessorBuilder>
{
    public Processor(ISocket socket, IEnumerable<int> supportedMemoryFrequencies, int coreFrequency, int coreNumber, double tdp, bool videoCore, int power)
    {
        Socket = socket;
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
        CoreFrequency = coreFrequency;
        CoreNumber = coreNumber;
        Tdp = tdp;
        VideoCore = videoCore;
        Power = power;
    }

    public int CoreFrequency { get; }
    public int CoreNumber { get; }
    public ISocket Socket { get; }
    public double Tdp { get; }
    public IEnumerable<int> SupportedMemoryFrequencies { get; }
    public bool VideoCore { get; }
    public int Power { get; }

    public CheckCompatibilityResult СheckСompatibility(IComponent component)
    {
        return component switch
        {
            IComponentWithSupportedProcessors componentWithSupportedProcessors when componentWithSupportedProcessors
                .SupportedProcessors.All(x => !x.Equals(this)) =>
                new CheckCompatibilityResult.NotСompatible(this, component),
            IComponentWithSupportedSockets componentWithSupportedSockets when
                componentWithSupportedSockets.SupportedSockets.All(x => x.Info != Socket.Info) =>
                new CheckCompatibilityResult.NotСompatible(this, component),
            IComponentWithBios componentWithBios when
                componentWithBios.Bios.SupportedProcessors.All(x => !x.Equals(this)) =>
                new CheckCompatibilityResult.NotСompatible(this, component),
            _ => new CheckCompatibilityResult.Сompatible(),
        };
    }

    public IProcessorBuilder Direct(IProcessorBuilder builder)
    {
        return builder.WithSupportedMemoryFrequencies(SupportedMemoryFrequencies)
            .WithPower(Power)
            .WithTpd(Tdp)
            .WithSocket(Socket)
            .WithCoreFrequency(CoreFrequency)
            .WithCoreNumber(CoreNumber)
            .WithVideoCore(VideoCore);
    }

    public bool Equals(IComponent? other)
    {
        return Equals(this, (object?)other);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Processor)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(CoreFrequency, CoreNumber, Socket, Tdp, SupportedMemoryFrequencies, VideoCore, Power);
    }

    protected bool Equals(Processor other)
    {
        return CoreFrequency == other.CoreFrequency && CoreNumber == other.CoreNumber && Socket.Equals(other.Socket) && Tdp.Equals(other.Tdp) && SupportedMemoryFrequencies.Equals(other.SupportedMemoryFrequencies) && VideoCore == other.VideoCore && Power == other.Power;
    }
}