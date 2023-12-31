using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.User;

public class ViewableMessage
{
    public ViewableMessage(Message message)
    {
        Message = message;
    }

    public Message Message { get; }
    public bool Viewed { get; private set; }

    public MarkViewedResult MarkViewed()
    {
        if (Viewed)
            return new MarkViewedResult.NotMarked();
        Viewed = !Viewed;
        return new MarkViewedResult.Marked();
    }
}