namespace Domain.Models;

public class Message(User user, string text, DateTime created)
{
    public User GetAuthor() => user;
    public override string ToString()
    {
        return $"User: {user}, Text: {text}, Created: {created}";
    }
}