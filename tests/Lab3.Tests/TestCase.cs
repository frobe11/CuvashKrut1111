using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.User;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messenger;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class TestCase
{
    [Fact]
    public void User_ReceiveMessage_NotViewed()
    {
        var user = new SystemUser("11", "Fobe");
        var userAddressee = new UserAddressee(user);
        var message = new Message("тест", "проверка проверка", ImportanceLevel.MinImportance);
        userAddressee.Receive(message);
        Assert.All(user.Mailbox, x => Assert.False(x.Viewed));
    }

    [Fact]
    public void User_ReceiveMessageAndMarkViewed_Viewed()
    {
        var user = new SystemUser("11", "Fobe");
        var userAddressee = new UserAddressee(user);
        var message = new Message("тест", "проверка проверка", ImportanceLevel.MinImportance);
        userAddressee.Receive(message);
        Assert.All(user.Mailbox, x =>
        {
            x.MarkViewed();
            Assert.True(x.Viewed);
        });
    }

    [Fact]
    public void User_TryMarkViewedAlreadyViewedMessage_Exception()
    {
        var user = new SystemUser("11", "Fobe");
        var userAddressee = new UserAddressee(user);
        var message = new Message("тест", "проверка проверка", ImportanceLevel.MinImportance);
        userAddressee.Receive(message);
        Assert.All(user.Mailbox, x =>
        {
            x.MarkViewed();
            Assert.True(x.MarkViewed() is MarkViewedResult.NotMarked);
        });
    }

    [Fact]
    public void AddresseeWithImportanceLevel_ReceiveMessageWithLowImportance_DidNotReceive()
    {
        IAddressee addressee = Substitute.For<IAddressee>();
        var importanceAddressee = new AddresseeWithImportanceLevel(addressee, ImportanceLevel.MaxImportance);
        var firstMessage = new Message("тест", "проверка проверка", ImportanceLevel.MinImportance);
        importanceAddressee.Receive(firstMessage);
        addressee.DidNotReceive().Receive(firstMessage);
        var secondMessage = new Message("тест", "проверка проверка", ImportanceLevel.MaxImportance);
        importanceAddressee.Receive(secondMessage);
        addressee.Received().Receive(secondMessage);
    }

    [Fact]
    public void AddresseeWithLog_ReceiveMessage_LoggerReceived()
    {
        IAddressee addressee = Substitute.For<IAddressee>();
        ILogger logger = Substitute.For<ILogger>();
        var loggerAddressee = new AddresseeWithLog(addressee, logger);
        var message = new Message("тест", "проверка проверка", ImportanceLevel.MinImportance);
        loggerAddressee.Receive(message);
        addressee.Received().Receive(message);
        logger.Received().Log(Arg.Any<string>());
    }

    [Fact]
    public void Messenger_ReceiveMessage_MessengerReceived()
    {
        IMessenger messenger = Substitute.For<IMessenger>();
        var messengerAddressee = new MessengerAddressee(messenger);
        var message = new Message("тест", "проверка проверка", ImportanceLevel.MinImportance);
        messengerAddressee.Receive(message);
        messenger.Received().Send(Arg.Any<string>());
    }
}