using Domain.Models.UserRoles;

namespace Domain.Models.UserFactory;

public class LeadDeveloperUserCreator: UserCreator
{
    public override User CreateUser(string name, string email) => new LeadDeveloper(name, email);
}