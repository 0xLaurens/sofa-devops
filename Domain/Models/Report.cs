using Domain.Interfaces;

namespace Domain.Models;

public abstract class Report(List<User> users, IExportStrategy exportStrategy, BurndownChart burndownChart)
{
    

 

    public abstract void Export();
}