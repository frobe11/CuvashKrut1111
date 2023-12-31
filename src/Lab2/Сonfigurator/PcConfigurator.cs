using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Components.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Components.CpuCooler;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MemoryDisks;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.PcieLine;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Components.VideoСard;
using Itmo.ObjectOrientedProgramming.Lab2.Components.WifiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.Сonfigurator;

public class PcConfigurator : IPcConfigurator
{
    private bool _warn;
    private bool _guarantee;
    private IVideoCard? _videoCard;
    private IProcessor? _processor;
    private ICpuCooler? _cpuCooler;
    private IBios? _bios;
    private IComputerCase? _case;
    private IEnumerable<IMemoryDisk>? _memoryDisks;
    private IEnumerable<IRam>? _rams;
    private IMotherboard? _motherboard;
    private IPowerUnit? _powerUnit;
    private IWifiAdapter? _wifiAdapter;
    private IXmp? _xmp;

    public PcConfigurator()
    {
        _warn = false;
        _guarantee = true;
        _videoCard = null;
        _processor = null;
        _cpuCooler = null;
        _bios = null;
        _case = null;
        _memoryDisks = null;
        _rams = null;
        _motherboard = null;
        _powerUnit = null;
        _wifiAdapter = null;
        _xmp = null;
    }

    private int Power
    {
        get
        {
            int power = 0;
            foreach (IComponent? component in Components)
            {
                if (component is IComponentWithPower componentWithPower)
                {
                    power += componentWithPower.Power;
                }
            }

            return power / 2;
        }
    }

    private IEnumerable<IComponent?> Components
    {
        get
        {
            var components = new List<IComponent?>
            {
                _videoCard,
                _processor,
                _cpuCooler,
                _bios,
                _case,
                _motherboard,
                _powerUnit,
                _wifiAdapter,
                _xmp,
            };
            if (_rams is not null)
                components.AddRange(_rams);
            if (_memoryDisks is not null)
                components.AddRange(_memoryDisks);
            return components;
        }
    }

    public PcConfigureResult Configure()
    {
        if (_processor is null
            | _motherboard is null
            | _cpuCooler is null
            | _powerUnit is null
            | _rams is null
            | _memoryDisks is null
            | _case is null)
        {
            _warn = true;
        }
        else if (_videoCard is null)
        {
            if (_processor != null) _warn = !_processor.VideoCore;
        }
        else
        {
            _warn = !CheckPorts();
        }

        if (_warn) return new PcConfigureResult.Warning();
        IEnumerable<IComponent?> components = Components;

        foreach (IComponent? component in components)
        {
            if (component is null) continue;
            foreach (IComponent? otherComponent in components)
            {
                if (component == otherComponent) continue;
                if (otherComponent is null) continue;
                CheckCompatibilityResult result = component.СheckСompatibility(otherComponent);
                if (result is not CheckCompatibilityResult.NotСompatible) continue;
                _warn = true;
                _guarantee = false;
            }
        }

        if (_guarantee & (Power > _powerUnit?.Power | _cpuCooler?.Tdp < _processor?.Tdp))
        {
            _guarantee = false;
        }

        if (_warn) return new PcConfigureResult.Warning();
        return new PcConfigureResult.NoWarns(_guarantee);
    }

    public IPcConfigurator WithVideoCard(IVideoCard videoCard)
    {
        _videoCard = videoCard;
        return this;
    }

    public IPcConfigurator WithProcessor(IProcessor processor)
    {
        _processor = processor;
        return this;
    }

    public IPcConfigurator WithCpuCooler(ICpuCooler cpuCooler)
    {
        _cpuCooler = cpuCooler;
        return this;
    }

    public IPcConfigurator WithBios(IBios bios)
    {
        _bios = bios;
        return this;
    }

    public IPcConfigurator WithComputerCase(IComputerCase computerCase)
    {
        _case = computerCase;
        return this;
    }

    public IPcConfigurator WithMemoryDisks(IEnumerable<IMemoryDisk> memoryDisks)
    {
        _memoryDisks = memoryDisks;
        return this;
    }

    public IPcConfigurator WithMotherboard(IMotherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public IPcConfigurator WithPowerUnit(IPowerUnit powerUnit)
    {
        _powerUnit = powerUnit;
        return this;
    }

    public IPcConfigurator WithRams(IEnumerable<IRam> rams)
    {
        _rams = rams;
        return this;
    }

    public IPcConfigurator WithWifiAdapter(IWifiAdapter wifiAdapter)
    {
        _wifiAdapter = wifiAdapter;
        return this;
    }

    public IPcConfigurator WithXmp(IXmp xmp)
    {
        _xmp = xmp;
        return this;
    }

    private bool CheckPorts()
    {
        IPcieLine? line = _motherboard?.PcieLine;
        if (line is null) return false;
        if (line.PcieX16Slots == 0 & _videoCard is not null)
            return false;
        if (line.PcieX1Slots == 0 & _wifiAdapter is not null)
            return false;
        if (_rams is not null)
        {
            int ramCount = 0;
            foreach (IRam ram in _rams)
            {
                ramCount++;
            }

            if (ramCount > _motherboard?.RamSlots) return false;
        }

        int sataCount = 0;
        int pcieM2Count = 0;
        if (_memoryDisks is not null)
        {
            foreach (IMemoryDisk disk in _memoryDisks)
            {
                switch (disk.ConnectionOption)
                {
                    case MemoryDiskConnectionOption.Sata:
                        sataCount++;
                        break;
                    case MemoryDiskConnectionOption.PciE:
                        pcieM2Count++;
                        break;
                }
            }
        }

        if (sataCount == 0 & pcieM2Count == 0 | sataCount > _motherboard?.SataPorts & pcieM2Count > line.PcieM2Slots)
            return false;

        return true;
    }
}