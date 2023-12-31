using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messenger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class MessengerAddressee : IAddressee
{
    private IMessenger _messenger;

    public MessengerAddressee(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void Receive(Message message)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(message.Header)
            .Append('\n')
            .Append(message.Body);
        _messenger.Send(stringBuilder.ToString());
    }
}