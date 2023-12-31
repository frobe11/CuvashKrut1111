using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeWithImportanceLevel : IAddressee
{
    private IAddressee _addressee;

    private ImportanceLevel _importanceLevel;

    public AddresseeWithImportanceLevel(IAddressee addressee, ImportanceLevel level)
    {
        _addressee = addressee;
        _importanceLevel = level;
    }

    public void Receive(Message message)
    {
        if (_importanceLevel <= message.ImportanceLevel)
        {
            _addressee.Receive(message);
        }
    }
}