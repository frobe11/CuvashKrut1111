using System;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Components.WifiAdapter.Builder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.WifiAdapter;

public class WifiAdapter : IWifiAdapter, IDirector<IWifiAdapterBuilder>
{
    public WifiAdapter(bool bluetooth, string wifiStandard, int power, int pcieVersion)
    {
        Bluetooth = bluetooth;
        WifiStandard = wifiStandard;
        Power = power;
        PcieVersion = pcieVersion;
    }

    public string WifiStandard { get; }
    public bool Bluetooth { get; }
    public int Power { get; }
    public int PcieVersion { get; }

    public IWifiAdapterBuilder Direct(IWifiAdapterBuilder builder)
    {
        return builder.WithBluetooth(Bluetooth)
            .WithPower(Power)
            .WithPcieVersion(PcieVersion)
            .WithWifiStandard(WifiStandard);
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
        return Equals((WifiAdapter)obj);
    }

    public CheckCompatibilityResult СheckСompatibility(IComponent component)
    {
        return new CheckCompatibilityResult.Сompatible();
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(WifiStandard, Bluetooth, Power, PcieVersion);
    }

    protected bool Equals(WifiAdapter other)
    {
        return WifiStandard == other.WifiStandard && Bluetooth == other.Bluetooth && Power == other.Power &&
               PcieVersion == other.PcieVersion;
    }
}