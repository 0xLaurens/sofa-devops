namespace Domain.Models.User;

// TEMPLATE PATTERN
public abstract class User
{
    private string _username;
    private string _email;

    public User(string username, string email)
    {
        _username = email;
        _email = email;
    }

    public string GetUsername()
    {
        return _username;
    }

    public string GetEmail()
    {
        return _email;
    }
}