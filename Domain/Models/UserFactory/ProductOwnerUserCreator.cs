using Domain.Models.UserRoles;

namespace Domain.Models.UserFactory;

public class ProductOwnerUserCreator: UserCreator
{
    public override User CreateUser(string name, string email) => new ProductOwner(name, email);
}