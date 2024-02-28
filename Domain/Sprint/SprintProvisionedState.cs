namespace Domain.Sprint;

public class SprintProvisionedState : ISprintState
{
    private ISprintContext _sprintContext;

    public SprintProvisionedState(ISprintContext sprintContext)
    {
        _sprintContext = sprintContext;
    }

    public void StartSprint()
    {
        _sprintContext.SetState(new SprintActiveState(_sprintContext));
    }

    public void FinishSprint()
    {
        throw new InvalidOperationException("Sprint has not been started yet!");
    }
}