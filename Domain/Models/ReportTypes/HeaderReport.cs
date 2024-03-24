using Domain.Interfaces;

namespace Domain.Models.ReportTypes;

public class HeaderReport(List<User> users, IExportStrategy exportStrategy, BurndownChart burndownChart) : Report(users, exportStrategy, burndownChart)
{
    public override void Export()
    {
        exportStrategy.ExportReport();
    }
}