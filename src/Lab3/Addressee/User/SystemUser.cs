using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.User;

public class SystemUser
{
    private List<ViewableMessage> _mailbox;
    public SystemUser(string id, string nickname)
    {
        Id = id;
        Nickname = nickname;
        _mailbox = new List<ViewableMessage>();
    }

    public string Id { get; }
    public string Nickname { get; }
    public IReadOnlyCollection<ViewableMessage> Mailbox => _mailbox;

    public void Receive(Message message)
    {
        _mailbox.Add(new ViewableMessage(message));
    }
}