using Domain.Interfaces;

namespace Domain.Models;

public class Footer(List<User> users, IExportStrategy exportStrategy, BurndownChart burndownChart) : Report(users, exportStrategy, burndownChart)
{
    public override void Export()
    {
        exportStrategy.ExportReport();
    }
}