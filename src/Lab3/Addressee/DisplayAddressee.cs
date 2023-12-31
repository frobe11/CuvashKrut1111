using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class DisplayAddressee : IAddressee
{
    private IDisplay _display;

    public DisplayAddressee(IDisplay display)
    {
        _display = display;
    }

    public void Receive(Message message)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(message.Header)
            .Append('\n')
            .Append(message.Body);
        _display.Display(stringBuilder.ToString());
    }
}