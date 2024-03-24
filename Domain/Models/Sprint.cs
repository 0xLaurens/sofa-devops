using Domain.Interfaces;
using Domain.Models.SprintState;

namespace Domain.Models;

public abstract class Sprint: ISprintContext
{
    private ISprintState _sprintState; 
    
    private Review _review;
    private string _name;
    private DateTime _startDate;
    private DateTime _endDate;
    private DateTime _created;
    private Backlog _sprintBacklog;

    protected Sprint(string name, DateTime startDate, DateTime endDate)
    {
        _sprintState = new SprintProvisionedState(this);
        _name = name;
        _startDate = startDate;
        _endDate = endDate;
        _created = DateTime.Now;
        _sprintBacklog = new Backlog();
        _review = new Review();
    }

    public void SetState(ISprintState state)
    {
        _sprintState = state;
    }

    public ISprintState GetState()
    {
        return _sprintState;
    }
    
    public void AddBacklogItem(BacklogItem item)
    {
        _sprintBacklog?.AddBacklogItem(item);
    }
    
    public void RemoveBacklogItem(BacklogItem item)
    {
        _sprintBacklog?.RemoveBacklogItem(item);
    }

    public void GenerateReport()
    {
        
    }
}