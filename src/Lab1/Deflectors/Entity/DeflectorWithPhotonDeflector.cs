namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entity;

public class DeflectorWithPhotonDeflector : DeflectorDecorator, IDeflectorWithPhotonDeflector
{
    public DeflectorWithPhotonDeflector(IDeflector deflector)
        : base(deflector)
    {
        PhotonDeflector = new PhotonDeflector();
    }

    public IPhotonDeflector PhotonDeflector { get; }
}