using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Topic
{
    private IAddressee _addressee;

    public Topic(IAddressee addressee, string name)
    {
        _addressee = addressee;
        Name = name;
    }

    public string Name { get; }

    public Topic Send(Message message)
    {
        _addressee.Receive(message);
        return this;
    }
}