namespace Domain;

public class CreatorDeveloper
{
    public Developer createUser(string username, string email)
    {
        return new Developer(username, email);
    }
}