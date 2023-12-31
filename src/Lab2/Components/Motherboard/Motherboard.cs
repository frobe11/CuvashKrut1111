using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.MotherboardFormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.PcieLine;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.RamFormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Socket;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Motherboard.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Motherboard;

public class Motherboard : IMotherboard, IDirector<IMotherboardBuilder>
{
    public Motherboard(
        ISocket socket,
        IBios bios,
        int ramSlots,
        int sataPorts,
        IPcieLine pcieLine,
        IChipset chipset,
        IMotherBoardFormFactor motherBoardFormFactor,
        IRamFormFactor ramFormFactor,
        int ddrStandard)
    {
        Socket = socket;
        Bios = bios;
        RamSlots = ramSlots;
        SataPorts = sataPorts;
        PcieLine = pcieLine;
        Chipset = chipset;
        MotherBoardFormFactor = motherBoardFormFactor;
        RamFormFactor = ramFormFactor;
        DdrStandard = ddrStandard;
    }

    public ISocket Socket { get; }
    public IBios Bios { get; }
    public int RamSlots { get; }
    public int SataPorts { get; }
    public IPcieLine PcieLine { get; }
    public IChipset Chipset { get; }
    public IMotherBoardFormFactor MotherBoardFormFactor { get; }
    public IRamFormFactor RamFormFactor { get; }
    public int DdrStandard { get; }

    public IMotherboardBuilder Direct(IMotherboardBuilder builder)
    {
        return builder.WithBios(Bios)
            .WithChipset(Chipset)
            .WithSocket(Socket)
            .WithDdrStandard(DdrStandard)
            .WithPcieLine(PcieLine)
            .WithRamSlots(RamSlots)
            .WithSataPorts(SataPorts)
            .WithMotherboardFormFactor(MotherBoardFormFactor)
            .WithRamFormFactor(RamFormFactor);
    }

    public CheckCompatibilityResult СheckСompatibility(IComponent component)
    {
        switch (component)
        {
            case IComponentWithSupportedMemoryFrequencies componentWithSupportedMemoryFrequencies:
            {
                bool match = false;
                foreach (int memory1 in Chipset.SupportedMemoryFrequencies)
                {
                    foreach (int memory2 in componentWithSupportedMemoryFrequencies.SupportedMemoryFrequencies)
                    {
                        if (memory1 == memory2) match = true;
                    }
                }

                if (!match) return new CheckCompatibilityResult.NotСompatible(this, component);
                break;
            }

            case IComponentWithSocket componentWithSocket when componentWithSocket.Socket != Socket:
                return new CheckCompatibilityResult.NotСompatible(this, component);
            case IComponentWithSupportedXmpProfiles componentWithSupportedXmpProfiles:
            {
                bool match = false;
                foreach (IXmp memory1 in Chipset.XmpProfiles)
                {
                    foreach (IXmp memory2 in componentWithSupportedXmpProfiles.XmpProfiles)
                    {
                        if (memory1.Equals(memory2)) match = true;
                    }
                }

                if (!match) return new CheckCompatibilityResult.NotСompatible(this, component);
                break;
            }

            case IComponentWithSupportedMotherboardFormFactor componentWithSupportedMotherboardFormFactor when componentWithSupportedMotherboardFormFactor.SupportedMotherboardFormFactor.All(x =>
                x.Info != MotherBoardFormFactor.Info):
                return new CheckCompatibilityResult.NotСompatible(this, component);
            case IComponentWithDdrStandard componentWithDdrStandard when componentWithDdrStandard.DdrStandard != DdrStandard:
                return new CheckCompatibilityResult.NotСompatible(this, component);
            case IComponentWithIRamFormFactor componentWithIRamFormFactor when componentWithIRamFormFactor.RamFormFactor.Info != RamFormFactor.Info:
                return new CheckCompatibilityResult.NotСompatible(this, component);
            case IComponentWithBios componentWithBios when !componentWithBios.Bios.Equals(Bios):
                return new CheckCompatibilityResult.NotСompatible(this, component);
            case IComponentWithPcieVersion componentWithPcieVersion when componentWithPcieVersion.PcieVersion != PcieLine.PcieVersion:
                return new CheckCompatibilityResult.NotСompatible(this, component);
        }

        return new CheckCompatibilityResult.Сompatible();
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
        return Equals((Motherboard)obj);
    }

    public override int GetHashCode()
    {
        var hashCode = default(HashCode);
        hashCode.Add(Socket);
        hashCode.Add(Bios);
        hashCode.Add(RamSlots);
        hashCode.Add(SataPorts);
        hashCode.Add(PcieLine);
        hashCode.Add(Chipset);
        hashCode.Add(MotherBoardFormFactor);
        hashCode.Add(RamFormFactor);
        hashCode.Add(DdrStandard);
        return hashCode.ToHashCode();
    }

    protected bool Equals(Motherboard other)
    {
        return Socket.Equals(other.Socket) && Bios.Equals(other.Bios) && RamSlots == other.RamSlots && SataPorts == other.SataPorts && PcieLine.Equals(other.PcieLine) && Chipset.Equals(other.Chipset) && MotherBoardFormFactor.Equals(other.MotherBoardFormFactor) && RamFormFactor.Equals(other.RamFormFactor) && DdrStandard == other.DdrStandard;
    }
}