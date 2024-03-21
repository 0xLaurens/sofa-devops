using Domain.Interfaces;

namespace Domain.Models.SprintState;

public class SprintActiveState(ISprintContext sprintContext) : ISprintState
{
    public void StartSprint()
    {
        throw new InvalidOperationException("Sprint is already active!");
    }

    public void FinishSprint()
    {
       sprintContext.SetState(new SprintFinishedState(sprintContext)); 
    }
}