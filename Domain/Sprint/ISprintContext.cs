namespace Domain.Sprint;

public interface ISprintContext
{
    public void SetState(ISprintState state);
    public ISprintState GetState();
}