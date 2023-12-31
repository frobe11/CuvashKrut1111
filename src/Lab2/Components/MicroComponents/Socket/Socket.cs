namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Socket;

public class Socket : ISocket
{
    public Socket(string info)
    {
        Info = info;
    }

    public string Info { get; }
}