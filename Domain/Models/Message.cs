namespace Domain.Models;

public class Message(User user, string text, DateTime created)
{
    private User _user = user;
    private string _text = text;
    private DateTime _created = created;
}