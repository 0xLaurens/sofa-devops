namespace Domain.Models;

public class Message
{
    private User _user;
    private string _text;
    private DateTime _created;

    public Message(User user, string text, DateTime created)
    {
        _user = user;
        _text = text;
        _created = created;
    }
}