using Domain.Interfaces;

namespace Domain.Models.SprintState;

public class SprintProvisionedState(ISprintContext sprintContext) : ISprintState
{
    public void StartSprint()
    {
        sprintContext.SetState(new SprintActiveState(sprintContext));
    }

    public void FinishSprint()
    {
        throw new InvalidOperationException("Sprint has not been started yet!");
    }
}