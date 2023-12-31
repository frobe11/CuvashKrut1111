using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger;

public class Telegramm : IMessenger
{
    public void Send(string text)
    {
        Console.WriteLine("telegramm: " + text);
    }
}