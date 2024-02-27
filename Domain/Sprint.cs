using Domain;


public class Sprint
{
    private SprintStatus _status;
    private Review _review;
    
    private string _name;
    private DateTime _startDate;
    private DateTime _endDate;
    private DateTime _created;
    private Backlog _sprintBacklog;

    public Sprint(string name, DateTime startDate, DateTime endDate)
    {
        _status = SprintStatus.Provisioned;
        _name = name;
        _startDate = startDate;
        _endDate = endDate;
        _created = DateTime.Now;
        _sprintBacklog = new Backlog();
        _review = new Review();
    }
}