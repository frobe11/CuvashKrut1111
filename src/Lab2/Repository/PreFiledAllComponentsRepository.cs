using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Components.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Components.CpuCooler;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MemoryDisks;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.MotherboardFormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.PcieLine;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.RamFormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Socket;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Components.VideoСard;
using Itmo.ObjectOrientedProgramming.Lab2.Components.WifiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class PreFiledAllComponentsRepository
{
    public PreFiledAllComponentsRepository()
    {
        BiosRepository = new Repository<Bios>();
        ComputerCaseRepository = new Repository<ComputerCase>();
        CpuCoolerRepository = new Repository<CpuCooler>();
        SsdRepository = new Repository<Ssd>();
        HddRepository = new Repository<Hdd>();
        MotherboardRepository = new Repository<Motherboard>();
        PowerUnitRepository = new Repository<PowerUnit>();
        ProcessorRepository = new Repository<Processor>();
        RamRepository = new Repository<Ram>();
        VideoCardRepository = new Repository<VideoCard>();
        WifiAdapterRepository = new Repository<WifiAdapter>();
        XmpRepository = new Repository<Xmp>();
        Fill();
    }

    public IRepository<Bios> BiosRepository { get; }
    public IRepository<ComputerCase> ComputerCaseRepository { get; }
    public IRepository<CpuCooler> CpuCoolerRepository { get; }
    public IRepository<Ssd> SsdRepository { get; }
    public IRepository<Hdd> HddRepository { get; }
    public IRepository<Motherboard> MotherboardRepository { get; }
    public IRepository<PowerUnit> PowerUnitRepository { get; }
    public IRepository<Processor> ProcessorRepository { get; }
    public IRepository<Ram> RamRepository { get; }
    public IRepository<VideoCard> VideoCardRepository { get; }
    public IRepository<WifiAdapter> WifiAdapterRepository { get; }
    public IRepository<Xmp> XmpRepository { get; }

    private void Fill()
    {
        FillXmpRepository();
        FillProcessorRepository();
        FillBiosRepository();
        FillComputerCaseRepository();
        FillCpuCoolerRepository();
        FillDiskRepository();
        FillMotherboardRepository();
        FillPowerUnitRepository();
        FillRamRepository();
        FillVideoCardRepository();
        FillWifiAdapterRepository();
    }

    private void FillXmpRepository()
    {
        XmpRepository.Add(
                "Useful XMP",
                new Xmp("1,2,3", 54, 12))
            .Add(
                "Useful XMP 1",
                new Xmp("3,2,1", 23, 100));
    }

    private void FillProcessorRepository()
    {
        ProcessorRepository.Add(
                "AMD Ryzen 5 5600X",
                new Processor(
                    new Socket("AM4"),
                    new Collection<int>
                    {
                        3200,
                        3000,
                        2700,
                    },
                    3700,
                    6,
                    65,
                    false,
                    65))
            .Add(
                "AMD Ryzen 5 5600G",
                new Processor(
                    new Socket("AM4"),
                    new Collection<int>
                    {
                        3200,
                        3000,
                        2700,
                    },
                    3900,
                    6,
                    65,
                    true,
                    65))
            .Add(
                "Intel Core i5",
                new Processor(
                    new Socket("LGA 1200"),
                    new Collection<int>
                    {
                        3100,
                        3050,
                        2750,
                    },
                    2600,
                    6,
                    65,
                    false,
                    65));
    }

    private void FillBiosRepository()
    {
        var supportedAmdProcessors = new Collection<IProcessor>
        {
            ProcessorRepository.GetComponent("AMD Ryzen 5 5600G"),
            ProcessorRepository.GetComponent("AMD Ryzen 5 5600X"),
        };
        var supportedIntelProcessors = new Collection<IProcessor>
        {
            ProcessorRepository.GetComponent("Intel Core i5"),
        };

        BiosRepository.Add("BIOS AMD", new Bios(
                supportedAmdProcessors,
                "bios",
                "1.0.0"))
            .Add(
                "BIOS Intel",
                new Bios(
                    supportedIntelProcessors,
                    "bios",
                    "1.0.0"));
    }

    private void FillComputerCaseRepository()
    {
        var supportedMotherboardFormFactorsBig = new Collection<IMotherBoardFormFactor>
        {
            new MotherBoardFormFactor("EATX"),
            new MotherBoardFormFactor("ATX"),
            new MotherBoardFormFactor("micro-ATX"),
            new MotherBoardFormFactor("mini-ITX"),
        };
        var supportedMotherboardFormFactorsSmall = new Collection<IMotherBoardFormFactor>
        {
            new MotherBoardFormFactor("micro-ATX"),
            new MotherBoardFormFactor("mini-ITX"),
        };

        ComputerCaseRepository.Add(
                "Big case",
                new ComputerCase(
                    100,
                    100,
                    supportedMotherboardFormFactorsBig,
                    new Dimension("big")))
            .Add(
                "Small case",
                new ComputerCase(
                    50,
                    50,
                    supportedMotherboardFormFactorsSmall,
                    new Dimension("small")));
    }

    private void FillCpuCoolerRepository()
    {
        CpuCoolerRepository.Add(
                "AeroCool1",
                new CpuCooler(
                    new Collection<ISocket>
                    {
                        new Socket("AM4"),
                        new Socket("LGA 1200"),
                    },
                    50,
                    new Dimension("normal")))
            .Add(
                "AeroCool100",
                new CpuCooler(
                    new Collection<ISocket>
                    {
                        new Socket("AM4"),
                        new Socket("LGA 1200"),
                    },
                    100,
                    new Dimension("normal")));
    }

    private void FillDiskRepository()
    {
        HddRepository.Add(
            "HDD 1TB",
            new Hdd(10, 25, 1000));
        SsdRepository.Add(
                "SSD 1TB SATA",
                new Ssd(
                    1000,
                    10,
                    MemoryDiskConnectionOption.Sata,
                    50))
            .Add(
                "SSD 1TB PCIe",
                new Ssd(
                    1000,
                    10,
                    MemoryDiskConnectionOption.PciE,
                    100));
    }

    private void FillMotherboardRepository()
    {
        MotherboardRepository.Add(
                "AMD motherboard",
                new Motherboard(
                    new Socket("AM4"),
                    BiosRepository.GetComponent("BIOS AMD"),
                    4,
                    4,
                    new PcieLine(1, 1, 2, 4),
                    new Chipset(
                        new List<int>
                        {
                            3700,
                            2700,
                            3200,
                        },
                        new IXmp[]
                        {
                            XmpRepository.GetComponent("Useful XMP"),
                            XmpRepository.GetComponent("Useful XMP 1"),
                        }),
                    new MotherBoardFormFactor("micro-ATX"),
                    new RamFormFactor("DIMM"),
                    4))
            .Add(
                "Intel motherboard",
                new Motherboard(
                    new Socket("LGA 1200"),
                    BiosRepository.GetComponent("BIOS Intel"),
                    4,
                    4,
                    new PcieLine(0, 1, 2, 4),
                    new Chipset(
                        new List<int>
                        {
                            000,
                            0000,
                            3100,
                        },
                        new IXmp[]
                        {
                            XmpRepository.GetComponent("Useful XMP"),
                            XmpRepository.GetComponent("Useful XMP 1"),
                        }),
                    new MotherBoardFormFactor("ATX"),
                    new RamFormFactor("SO-DIMM"),
                    3));
    }

    private void FillPowerUnitRepository()
    {
        PowerUnitRepository.Add(
                "Power12",
                new PowerUnit(12))
            .Add(
                "Power1000",
                new PowerUnit(1000));
    }

    private void FillRamRepository()
    {
        RamRepository.Add(
                "RAM8",
                new Ram(
                    new RamFormFactor("SO-DIMM"),
                    new int[]
                    {
                        1000,
                        2000,
                        3200,
                    },
                    new IXmp[]
                    {
                        XmpRepository.GetComponent("Useful XMP"),
                        XmpRepository.GetComponent("Useful XMP 1"),
                    },
                    20,
                    4,
                    8))
            .Add(
                "RAM16",
                new Ram(
                    new RamFormFactor("DIMM"),
                    new int[]
                    {
                        1000,
                        2000,
                        3200,
                    },
                    new IXmp[]
                    {
                        XmpRepository.GetComponent("Useful XMP"),
                        XmpRepository.GetComponent("Useful XMP 1"),
                    },
                    40,
                    4,
                    16));
    }

    private void FillVideoCardRepository()
    {
        VideoCardRepository.Add(
            "GeForce RTX 3060 Ti",
            new VideoCard(
                12,
                30,
                1410,
                8,
                225,
                4));
    }

    private void FillWifiAdapterRepository()
    {
        WifiAdapterRepository.Add(
            "TP-LINK Archer T5E",
            new WifiAdapter(
                true,
                "4,5",
                10,
                4));
    }
}