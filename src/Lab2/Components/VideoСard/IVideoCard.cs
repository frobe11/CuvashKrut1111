using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.VideoСard;

public interface IVideoCard
    : IComponent,
      ISizeComparer,
      IComponentWithPower,
      IComponentWithPcieVersion
{ }