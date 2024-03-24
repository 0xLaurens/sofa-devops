using Domain.Interfaces;

namespace Domain.Models.ReportTypes;

public class FooterReport(List<User> users, IExportStrategy exportStrategy, BurndownChart burndownChart) : Report(users, exportStrategy, burndownChart)
{
    public override void Export()
    {
        exportStrategy.ExportReport();
    }
}