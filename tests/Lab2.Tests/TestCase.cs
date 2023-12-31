using Itmo.ObjectOrientedProgramming.Lab2.Components.MemoryDisks;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Сonfigurator;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class TestCase
{
    [Fact]
    public void PcConfigurator_NoCase_Warning()
    {
        var r = new PreFiledAllComponentsRepository();
        var configurator = new PcConfigurator();
        PcConfigureResult result = configurator.WithMotherboard(r.MotherboardRepository.GetComponent("AMD motherboard"))
            .WithProcessor(r.ProcessorRepository.GetComponent("AMD Ryzen 5 5600X"))
            .WithRams(
        new IRam[]
        {
            r.RamRepository.GetComponent("RAM16"),
            r.RamRepository.GetComponent("RAM16"),
            r.RamRepository.GetComponent("RAM16"),
            r.RamRepository.GetComponent("RAM16"),
        })
            .WithCpuCooler(r.CpuCoolerRepository.GetComponent("AeroCool1"))
            .WithMemoryDisks(
                new IMemoryDisk[]
                {
                    r.HddRepository.GetComponent("HDD 1TB"),
                    r.HddRepository.GetComponent("HDD 1TB"),
                })
            .WithPowerUnit(r.PowerUnitRepository.GetComponent("Power12"))
            .WithVideoCard(r.VideoCardRepository.GetComponent("GeForce RTX 3060 Ti"))
            .Configure();
        Assert.True(result is PcConfigureResult.Warning);
    }

    [Fact]
    public void PcConfigurator_WrongProcessor_Warning()
    {
        var r = new PreFiledAllComponentsRepository();
        var configurator = new PcConfigurator();
        PcConfigureResult result = configurator.WithMotherboard(r.MotherboardRepository.GetComponent("AMD motherboard"))
            .WithProcessor(r.ProcessorRepository.GetComponent("Intel Core i5"))
            .WithRams(
                new IRam[]
                {
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                })
            .WithCpuCooler(r.CpuCoolerRepository.GetComponent("AeroCool100"))
            .WithMemoryDisks(
                new IMemoryDisk[]
                {
                    r.HddRepository.GetComponent("HDD 1TB"),
                    r.SsdRepository.GetComponent("SSD 1TB SATA"),
                })
            .WithPowerUnit(r.PowerUnitRepository.GetComponent("Power1000"))
            .WithVideoCard(r.VideoCardRepository.GetComponent("GeForce RTX 3060 Ti"))
            .WithComputerCase(r.ComputerCaseRepository.GetComponent("Big case"))
            .Configure();
        Assert.True(result is PcConfigureResult.Warning);
    }

    [Fact]
    public void PcConfigurator_WrongMotherboard_Warning()
    {
        var r = new PreFiledAllComponentsRepository();
        var configurator = new PcConfigurator();
        PcConfigureResult result = configurator.WithMotherboard(r.MotherboardRepository.GetComponent("Intel motherboard"))
            .WithProcessor(r.ProcessorRepository.GetComponent("AMD Ryzen 5 5600X"))
            .WithRams(
                new IRam[]
                {
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                })
            .WithCpuCooler(r.CpuCoolerRepository.GetComponent("AeroCool100"))
            .WithMemoryDisks(
                new IMemoryDisk[]
                {
                    r.HddRepository.GetComponent("HDD 1TB"),
                    r.SsdRepository.GetComponent("SSD 1TB SATA"),
                })
            .WithPowerUnit(r.PowerUnitRepository.GetComponent("Power1000"))
            .WithVideoCard(r.VideoCardRepository.GetComponent("GeForce RTX 3060 Ti"))
            .WithComputerCase(r.ComputerCaseRepository.GetComponent("Big case"))
            .Configure();
        Assert.True(result is PcConfigureResult.Warning);
    }

    [Fact]
    public void PcConfigurator_TooManyRams_Warning()
    {
        var r = new PreFiledAllComponentsRepository();
        var configurator = new PcConfigurator();
        PcConfigureResult result = configurator.WithMotherboard(r.MotherboardRepository.GetComponent("AMD motherboard"))
            .WithProcessor(r.ProcessorRepository.GetComponent("AMD Ryzen 5 5600X"))
            .WithRams(
                new IRam[]
                {
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                })
            .WithCpuCooler(r.CpuCoolerRepository.GetComponent("AeroCool100"))
            .WithMemoryDisks(
                new IMemoryDisk[]
                {
                    r.HddRepository.GetComponent("HDD 1TB"),
                    r.SsdRepository.GetComponent("SSD 1TB SATA"),
                })
            .WithPowerUnit(r.PowerUnitRepository.GetComponent("Power1000"))
            .WithVideoCard(r.VideoCardRepository.GetComponent("GeForce RTX 3060 Ti"))
            .WithComputerCase(r.ComputerCaseRepository.GetComponent("Big case"))
            .Configure();
        Assert.True(result is PcConfigureResult.Warning);
    }

    [Fact]
    public void PcConfigurator_CorrectComponents_NoWarning()
    {
        var r = new PreFiledAllComponentsRepository();
        var configurator = new PcConfigurator();
        PcConfigureResult result = configurator.WithMotherboard(r.MotherboardRepository.GetComponent("AMD motherboard"))
            .WithProcessor(r.ProcessorRepository.GetComponent("AMD Ryzen 5 5600X"))
            .WithRams(
                new IRam[]
                {
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                })
            .WithCpuCooler(r.CpuCoolerRepository.GetComponent("AeroCool100"))
            .WithMemoryDisks(
                new IMemoryDisk[]
                {
                    r.HddRepository.GetComponent("HDD 1TB"),
                    r.SsdRepository.GetComponent("SSD 1TB SATA"),
                })
            .WithPowerUnit(r.PowerUnitRepository.GetComponent("Power1000"))
            .WithVideoCard(r.VideoCardRepository.GetComponent("GeForce RTX 3060 Ti"))
            .WithComputerCase(r.ComputerCaseRepository.GetComponent("Big case"))
            .Configure();
        Assert.True(result is PcConfigureResult.NoWarns);
        if (result is PcConfigureResult.NoWarns noWarns)
        {
            Assert.True(noWarns.Guarantee);
        }
    }

    [Fact]
    public void PcConfigurator_WrongCooler_NoWarningNoGuarantee()
    {
        var r = new PreFiledAllComponentsRepository();
        var configurator = new PcConfigurator();
        PcConfigureResult result = configurator.WithMotherboard(r.MotherboardRepository.GetComponent("AMD motherboard"))
            .WithProcessor(r.ProcessorRepository.GetComponent("AMD Ryzen 5 5600X"))
            .WithRams(
                new IRam[]
                {
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                })
            .WithCpuCooler(r.CpuCoolerRepository.GetComponent("AeroCool1"))
            .WithMemoryDisks(
                new IMemoryDisk[]
                {
                    r.HddRepository.GetComponent("HDD 1TB"),
                    r.SsdRepository.GetComponent("SSD 1TB SATA"),
                })
            .WithPowerUnit(r.PowerUnitRepository.GetComponent("Power1000"))
            .WithVideoCard(r.VideoCardRepository.GetComponent("GeForce RTX 3060 Ti"))
            .WithComputerCase(r.ComputerCaseRepository.GetComponent("Big case"))
            .Configure();
        Assert.True(result is PcConfigureResult.NoWarns);
        if (result is PcConfigureResult.NoWarns noWarns)
        {
            Assert.False(noWarns.Guarantee);
        }
    }

    [Fact]
    public void PcConfigurator_WrongPowerUnit_NoWarningNoGuarantee()
    {
        var r = new PreFiledAllComponentsRepository();
        var configurator = new PcConfigurator();
        PcConfigureResult result = configurator.WithMotherboard(r.MotherboardRepository.GetComponent("AMD motherboard"))
            .WithProcessor(r.ProcessorRepository.GetComponent("AMD Ryzen 5 5600X"))
            .WithRams(
                new IRam[]
                {
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                })
            .WithCpuCooler(r.CpuCoolerRepository.GetComponent("AeroCool100"))
            .WithMemoryDisks(
                new IMemoryDisk[]
                {
                    r.HddRepository.GetComponent("HDD 1TB"),
                    r.SsdRepository.GetComponent("SSD 1TB SATA"),
                })
            .WithPowerUnit(r.PowerUnitRepository.GetComponent("Power12"))
            .WithVideoCard(r.VideoCardRepository.GetComponent("GeForce RTX 3060 Ti"))
            .WithComputerCase(r.ComputerCaseRepository.GetComponent("Big case"))
            .Configure();
        Assert.True(result is PcConfigureResult.NoWarns);
        if (result is PcConfigureResult.NoWarns noWarns)
        {
            Assert.False(noWarns.Guarantee);
        }
    }

    [Fact]
    public void PcConfigurator_ProcessorWithGpuNoVideoCard_NoWarning()
    {
        var r = new PreFiledAllComponentsRepository();
        var configurator = new PcConfigurator();
        PcConfigureResult result = configurator.WithMotherboard(r.MotherboardRepository.GetComponent("AMD motherboard"))
            .WithProcessor(r.ProcessorRepository.GetComponent("AMD Ryzen 5 5600G"))
            .WithRams(
                new IRam[]
                {
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                    r.RamRepository.GetComponent("RAM16"),
                })
            .WithCpuCooler(r.CpuCoolerRepository.GetComponent("AeroCool100"))
            .WithMemoryDisks(
                new IMemoryDisk[]
                {
                    r.HddRepository.GetComponent("HDD 1TB"),
                    r.SsdRepository.GetComponent("SSD 1TB SATA"),
                })
            .WithPowerUnit(r.PowerUnitRepository.GetComponent("Power1000"))
            .WithComputerCase(r.ComputerCaseRepository.GetComponent("Big case"))
            .Configure();
        Assert.True(result is PcConfigureResult.NoWarns);
        if (result is PcConfigureResult.NoWarns noWarns)
        {
            Assert.True(noWarns.Guarantee);
        }
    }
}