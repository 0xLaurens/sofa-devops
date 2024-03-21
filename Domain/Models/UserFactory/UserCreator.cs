namespace Domain.Models.UserFactory;

public abstract class UserCreator
{
    public abstract User CreateUser(string name, string email);
}