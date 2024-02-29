namespace Domain.Report;

public interface IReportLayout
{


    public void SetName(string name);
    public string GetName();
    public void SetProjectName(string name);
    public string GetProjectName();
    public void SetVersion(int version);
    public int GetVersion();
    public void SetDate(DateTime date);
    public DateTime GetDate();
}