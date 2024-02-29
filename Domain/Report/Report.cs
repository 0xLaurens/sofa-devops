namespace Domain.Report;

public class Report
{
    private IExportStrategy _exportStrategy;
    private List<User> _users;
    private Burndownchart _burndownChart;
    private Footer _footer;
    private Header _header;

    public void ExportReport()
    {
        _exportStrategy.ExportReport();
    }

    public void SetStrategy(IExportStrategy exportStrategy)
    {
        _exportStrategy = exportStrategy;
    }
}