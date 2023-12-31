namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.PcieLine;

public class PcieLine : IPcieLine
{
    public PcieLine(int pcieX1Slots, int pcieX16Slots, int pcieM2Slots, int pcieVersion)
    {
        PcieX1Slots = pcieX1Slots;
        PcieX16Slots = pcieX16Slots;
        PcieM2Slots = pcieM2Slots;
        PcieVersion = pcieVersion;
    }

    public int PcieX1Slots { get; }
    public int PcieX16Slots { get; }
    public int PcieM2Slots { get; }
    public int PcieVersion { get; }
}