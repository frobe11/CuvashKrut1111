using Itmo.ObjectOrientedProgramming.Lab3.Addressee.User;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class UserAddressee : IAddressee
{
    private SystemUser _user;

    public UserAddressee(SystemUser user)
    {
        _user = user;
    }

    public void Receive(Message message)
    {
        _user.Receive(message);
    }
}