using Domain.Models;

namespace Domain.Interfaces;

public interface ISprintState
{
    public void StartSprint();
    public void FinishSprint();
    public void CreateSprintReview(string description);
    public void StartRelease(User user);
}