using Domain.Interfaces;

namespace Domain.Models;

public abstract class Report(List<User> users, IExportStrategy exportStrategy, BurndownChart burndownChart)
{
    public IExportStrategy SetExportStrategy() => exportStrategy;

    public List<Domain.Models.User> GetUsers()
    {
        return users;
    }

    public abstract void Export();
}