using Domain.Interfaces;

namespace Domain.Models.SprintState;

public class SprintContext: ISprintContext
{
    private ISprintState _state;
    private Backlog _backlog;
    private DateTime _startdate;
    private DateTime _enddate;
    
    public void SetState(ISprintState state)
    {
        _state = state;
    }

    public ISprintState GetState()
    {
        return _state;
    }
    
    public void SetBacklog(Backlog backlog)
    {
        _backlog = backlog;
    }

    public Backlog GetBacklog()
    {
        return _backlog;
    }

    public DateTime GetStartDate()
    {
        return _startdate;
    }

    public DateTime GetEndDate()
    {
        return _enddate;
    }
}