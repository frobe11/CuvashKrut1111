using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Components.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Components.CpuCooler;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MemoryDisks;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Components.VideoСard;
using Itmo.ObjectOrientedProgramming.Lab2.Components.WifiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.Сonfigurator;

public interface IPcConfigurator
{
    PcConfigureResult Configure();
    IPcConfigurator WithVideoCard(IVideoCard videoCard);
    IPcConfigurator WithProcessor(IProcessor processor);
    IPcConfigurator WithCpuCooler(ICpuCooler cpuCooler);
    IPcConfigurator WithBios(IBios bios);
    IPcConfigurator WithComputerCase(IComputerCase computerCase);
    IPcConfigurator WithMemoryDisks(IEnumerable<IMemoryDisk> memoryDisks);
    IPcConfigurator WithMotherboard(IMotherboard motherboard);
    IPcConfigurator WithPowerUnit(IPowerUnit powerUnit);
    IPcConfigurator WithRams(IEnumerable<IRam> rams);
    IPcConfigurator WithWifiAdapter(IWifiAdapter wifiAdapter);
    IPcConfigurator WithXmp(IXmp xmp);
}