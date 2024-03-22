using Domain.Interfaces;

namespace Domain.Models.SprintState;

public class SprintFinishedState(ISprintContext sprintContext) : ISprintState
{
    private ISprintContext _sprintContext = sprintContext;

    public void StartSprint()
    {
        throw new InvalidOperationException("Cannot start a finished sprint!");
    }

    public void FinishSprint()
    {
        throw new InvalidOperationException("Sprint has already finished!");
    }
}