namespace Domain.Sprint;

public class SprintFinishedState : ISprintState
{
    private ISprintContext _sprintContext;

    public SprintFinishedState(ISprintContext sprintContext)
    {
        _sprintContext = sprintContext;
    }

    public void StartSprint()
    {
        throw new InvalidOperationException("Cannot start a finished sprint!");
    }

    public void FinishSprint()
    {
        throw new InvalidOperationException("Sprint has already finished!");
    }
}