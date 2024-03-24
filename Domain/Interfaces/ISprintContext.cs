namespace Domain.Interfaces;

public interface ISprintContext
{
    public void SetState(ISprintState state);
    public ISprintState GetState();
    public void CreateSprintReview(string description);
}