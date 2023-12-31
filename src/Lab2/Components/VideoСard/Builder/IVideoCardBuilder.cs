namespace Itmo.ObjectOrientedProgramming.Lab2.Components.VideoСard.Builder;

public interface IVideoCardBuilder
{
    IVideoCardBuilder WithSizes(int height, int width);
    IVideoCardBuilder WithVideoMemoryCapacity(int videoMemoryCapacity);
    IVideoCardBuilder WithPcieVersion(int version);
    IVideoCardBuilder WithChipFrequency(int frequency);
    IVideoCardBuilder WithPower(int power);
    IVideoCard Build();
}