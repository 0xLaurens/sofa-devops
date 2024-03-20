namespace Domain.Models.UserRoles;

public class Developer: User.User
{
    public Developer(string username, string email) : base(username, email)
    {
    }
}