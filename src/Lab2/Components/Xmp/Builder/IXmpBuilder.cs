namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Xmp.Builder;

public interface IXmpBuilder
{
    IXmpBuilder WithTimings(string timings);
    IXmpBuilder WithVoltage(int voltage);
    IXmpBuilder WithFrequency(int frequency);
    IXmp Build();
}