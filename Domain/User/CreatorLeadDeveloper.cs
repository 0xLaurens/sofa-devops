namespace Domain;

public class CreatorLeadDeveloper
{
    public LeadDeveloper createUser(string username, string email)
    {
        return new LeadDeveloper(username, email);
    }
}