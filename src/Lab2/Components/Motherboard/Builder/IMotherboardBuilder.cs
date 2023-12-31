using Itmo.ObjectOrientedProgramming.Lab2.Components.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.MotherboardFormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.PcieLine;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.RamFormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Motherboard.Builder;

public interface IMotherboardBuilder
{
    IMotherboardBuilder WithSocket(ISocket socket);
    IMotherboardBuilder WithPcieLine(IPcieLine line);
    IMotherboardBuilder WithSataPorts(int number);
    IMotherboardBuilder WithChipset(IChipset chipset);
    IMotherboardBuilder WithDdrStandard(int ddrStandard);
    IMotherboardBuilder WithRamSlots(int number);
    IMotherboardBuilder WithMotherboardFormFactor(IMotherBoardFormFactor motherBoardFormFactor);
    IMotherboardBuilder WithRamFormFactor(IRamFormFactor ramFormFactor);
    IMotherboardBuilder WithBios(IBios bios);
    IMotherboard Build();
}