using Domain.Models.UserRoles;

namespace Domain.Models.UserFactory;

public class ScrumMasterUserCreator: UserCreator
{
    public override User CreateUser(string name, string email) => new ScrumMaster(name, email);
}