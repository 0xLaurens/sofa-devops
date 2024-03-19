namespace Domain;

public class CreatorProductOwner
{
    public ProductOwner createUser(string username, string email)
    {
        return new ProductOwner(username, email);
    }
}