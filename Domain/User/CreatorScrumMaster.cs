namespace Domain;

public class CreatorScrumMaster
{
    public ScrumMaster createUser(string username, string email)
    {
        return new ScrumMaster(username, email);
    }
}