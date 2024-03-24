using Domain.Interfaces;

namespace Domain.Models;

public class Header(List<User> users, IExportStrategy exportStrategy, BurndownChart burndownChart) : Report(users, exportStrategy, burndownChart)
{
    public override void Export()
    {
        exportStrategy.ExportReport();
    }
}