namespace Domain.Models.UserRoles;

public class ProductOwner: User.User
{
    public ProductOwner(string username, string email) : base(username, email)
    {
    }
}