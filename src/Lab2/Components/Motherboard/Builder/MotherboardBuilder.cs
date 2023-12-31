using System;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.MotherboardFormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.PcieLine;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.RamFormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Motherboard.Builder;

public class MotherboardBuilder : IMotherboardBuilder
{
    private ISocket? _socket;
    private IPcieLine? _pcieLine;
    private int _sataPortsNumber;
    private IChipset? _chipset;
    private int _ddrStandard;
    private int _ramSlotsNumber;
    private IMotherBoardFormFactor? _motherBoardFormFactor;
    private IRamFormFactor? _ramFormFactor;
    private IBios? _bios;
    public IMotherboardBuilder WithSocket(ISocket socket)
    {
        _socket = socket;
        return this;
    }

    public IMotherboardBuilder WithPcieLine(IPcieLine line)
    {
        _pcieLine = line;
        return this;
    }

    public IMotherboardBuilder WithSataPorts(int number)
    {
        _sataPortsNumber = number;
        return this;
    }

    public IMotherboardBuilder WithChipset(IChipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public IMotherboardBuilder WithDdrStandard(int ddrStandard)
    {
        _ddrStandard = ddrStandard;
        return this;
    }

    public IMotherboardBuilder WithRamSlots(int number)
    {
        _ramSlotsNumber = number;
        return this;
    }

    public IMotherboardBuilder WithMotherboardFormFactor(IMotherBoardFormFactor motherBoardFormFactor)
    {
        _motherBoardFormFactor = motherBoardFormFactor;
        return this;
    }

    public IMotherboardBuilder WithRamFormFactor(IRamFormFactor ramFormFactor)
    {
        _ramFormFactor = ramFormFactor;
        return this;
    }

    public IMotherboardBuilder WithBios(IBios bios)
    {
        _bios = bios;
        return this;
    }

    public IMotherboard Build()
    {
        return new Motherboard(
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _bios ?? throw new ArgumentNullException(nameof(_bios)),
            _ramSlotsNumber,
            _sataPortsNumber,
            _pcieLine ?? throw new ArgumentNullException(nameof(_pcieLine)),
            _chipset ?? throw new ArgumentNullException(nameof(_chipset)),
            _motherBoardFormFactor ?? throw new ArgumentNullException(nameof(_motherBoardFormFactor)),
            _ramFormFactor ?? throw new ArgumentNullException(nameof(_ramFormFactor)),
            _ddrStandard);
    }
}