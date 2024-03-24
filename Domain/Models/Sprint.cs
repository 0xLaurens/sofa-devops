using Domain.Interfaces;
using Domain.Models.SprintState;
using Domain.Models.UserRoles;

namespace Domain.Models;

public abstract class Sprint : ISprintContext
{
    private ISprintState _sprintState;

    private Review _review;
    private string _name;
    private DateTime _startDate;
    private DateTime _endDate;
    private DateTime _created;
    private Backlog _sprintBacklog;
    private Pipeline _pipeline = new();
    private List<User> _teamMembers = [];

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
    
    public void AddMember(User user)
    {
        if (user.GetType() == typeof(ScrumMaster) && _teamMembers.Any(x => x.GetType() == typeof(ScrumMaster)))
        {
            throw new InvalidOperationException("Only one Scrum Master is allowed.");
        }
        
        _teamMembers.Add(user);
    }
    
    public void RemoveMember(User user)
    {
        _teamMembers.Remove(user);
    }

    public void RemoveBacklogItem(BacklogItem item)
    {
        _sprintBacklog?.RemoveBacklogItem(item);
    }

    public void SetPipeline(Pipeline pipeline)
    {
        _pipeline = pipeline;
    }

    public void ExecutePipeline(User user)
    {
        if (user.GetType() != typeof(ScrumMaster))
        {
            throw new InvalidOperationException("Only Scrum Master can execute pipeline.");
        }

        if (_pipeline is null)
        {
            throw new InvalidOperationException("Pipeline is not set.");
        }

        if (_sprintState.GetType() != typeof(SprintFinishedState))
        {
            throw new InvalidOperationException("Sprint is not finished.");
        }

        _pipeline.ExecutePipeline();
    }

    public void GenerateReport(Report report)
    {
        report.Export();
    }
}