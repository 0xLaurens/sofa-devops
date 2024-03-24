using Domain.Models;

namespace Domain.Interfaces;

public interface ISprintContext
{
    public void SetState(ISprintState state);
    public ISprintState GetState();
    public void CreateSprintReview(string description);
    public void StartRelease(User user);
    
    public void SetBacklog(Backlog backlog);

    public Backlog GetBacklog();

    public DateTime GetStartDate();

    public DateTime GetEndDate();
}