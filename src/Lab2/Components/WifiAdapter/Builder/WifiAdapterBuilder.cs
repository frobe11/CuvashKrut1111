using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.WifiAdapter.Builder;

public class WifiAdapterBuilder : IWifiAdapterBuilder
{
    private string? _wifiStandard;
    private int _power;
    private bool _withBluetoth;
    private int _pcieVersion;
    public IWifiAdapterBuilder WithWifiStandard(string standard)
    {
        _wifiStandard = standard;
        return this;
    }

    public IWifiAdapterBuilder WithPower(int power)
    {
        _power = power;
        return this;
    }

    public IWifiAdapterBuilder WithBluetooth(bool withBluetooth)
    {
        _withBluetoth = withBluetooth;
        return this;
    }

    public IWifiAdapterBuilder WithPcieVersion(int version)
    {
        _pcieVersion = version;
        return this;
    }

    public IWifiAdapter Build()
    {
        return new WifiAdapter(
            _withBluetoth,
            _wifiStandard ?? throw new ArgumentNullException(nameof(_wifiStandard)),
            _power,
            _pcieVersion);
    }
}