namespace Domain.Models;

// TEMPLATE PATTERN
public abstract class User(string username, string email)
{
    public string GetUsername() => username;
    public string GetEmail() => email;
    
    
}