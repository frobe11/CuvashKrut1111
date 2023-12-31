using System;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Components.VideoСard.Builder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.VideoСard;

public class VideoCard : IVideoCard, IDirector<IVideoCardBuilder>
{
    private readonly int _height;
    private readonly int _width;

    public VideoCard(int width, int height, int chipFrequency, int videoMemoryCapacity, int power, int pcieVersion)
    {
        ChipFrequency = chipFrequency;
        _width = width;
        _height = height;
        VideoMemoryCapacity = videoMemoryCapacity;
        Power = power;
        PcieVersion = pcieVersion;
    }

    public int VideoMemoryCapacity { get; }
    public int ChipFrequency { get; }
    public int Power { get; }
    public int PcieVersion { get; }

    public CheckCompatibilityResult СheckСompatibility(IComponent component)
    {
        if (component is not ISizeComparer sizeComparer) return new CheckCompatibilityResult.Сompatible();
        if (!sizeComparer.CompareSizes(_height, _width))
            return new CheckCompatibilityResult.NotСompatible(this, component);

        return new CheckCompatibilityResult.Сompatible();
    }

    public bool CompareSizes(int height, int width)
    {
        return _height < height & _width < width;
    }

    public IVideoCardBuilder Direct(IVideoCardBuilder builder)
    {
        return builder.WithPower(Power)
            .WithSizes(_height, _width)
            .WithPcieVersion(PcieVersion)
            .WithChipFrequency(ChipFrequency)
            .WithVideoMemoryCapacity(VideoMemoryCapacity);
    }

    public bool Equals(IComponent? other)
    {
        return Equals(this, other);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((VideoCard)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_height, _width, VideoMemoryCapacity, ChipFrequency, Power, PcieVersion);
    }

    protected bool Equals(VideoCard other)
    {
        return _height == other._height && _width == other._width && VideoMemoryCapacity == other.VideoMemoryCapacity &&
               ChipFrequency == other.ChipFrequency && Power == other.Power && PcieVersion == other.PcieVersion;
    }
}