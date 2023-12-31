using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeWithLog : IAddressee
{
    private IAddressee _addressee;
    private ILogger _logger;

    public AddresseeWithLog(IAddressee addressee, ILogger logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

    public void Receive(Message message)
    {
        _logger.Log(message.Header);
        _addressee.Receive(message);
    }
}