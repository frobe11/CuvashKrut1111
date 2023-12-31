namespace Itmo.ObjectOrientedProgramming.Lab2.Components.WifiAdapter.Builder;

public interface IWifiAdapterBuilder
{
    IWifiAdapterBuilder WithWifiStandard(string standard);
    IWifiAdapterBuilder WithPower(int power);
    IWifiAdapterBuilder WithBluetooth(bool withBluetooth);
    IWifiAdapterBuilder WithPcieVersion(int version);
    IWifiAdapter Build();
}