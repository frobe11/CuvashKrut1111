namespace Itmo.ObjectOrientedProgramming.Lab2.Components.VideoСard.Builder;

public class VideoCardBuilder : IVideoCardBuilder
{
    private int _width;
    private int _height;
    private int _videoMemoryCapacity;
    private int _pcieVersion;
    private int _chipFrequency;
    private int _power;
    public IVideoCardBuilder WithSizes(int height, int width)
    {
        _height = height;
        _width = width;
        return this;
    }

    public IVideoCardBuilder WithVideoMemoryCapacity(int videoMemoryCapacity)
    {
        _videoMemoryCapacity = videoMemoryCapacity;
        return this;
    }

    public IVideoCardBuilder WithPcieVersion(int version)
    {
        _pcieVersion = version;
        return this;
    }

    public IVideoCardBuilder WithChipFrequency(int frequency)
    {
        _chipFrequency = frequency;
        return this;
    }

    public IVideoCardBuilder WithPower(int power)
    {
        _power = power;
        return this;
    }

    public IVideoCard Build()
    {
        return new VideoCard(
            _width,
            _height,
            _chipFrequency,
            _videoMemoryCapacity,
            _power,
            _pcieVersion);
    }
}