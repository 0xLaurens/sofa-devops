using Domain.Models.UserRoles;

namespace Domain.Models.UserFactory;

public class DeveloperUserCreator: UserCreator
{
    public override User CreateUser(string name, string email) => new Developer(name, email);
}