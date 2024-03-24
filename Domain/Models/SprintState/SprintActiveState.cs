using Domain.Interfaces;

namespace Domain.Models.SprintState;

public class SprintActiveState: ISprintState
{
    private ISprintContext _sprintContext;
    
    public SprintActiveState(ISprintContext sprintContext)
    {
        _sprintContext = sprintContext;
    } 
    
    public void StartSprint()
    {
        throw new InvalidOperationException("Sprint is already active!");
    }

    public void FinishSprint()
    {
       _sprintContext.SetState(new SprintFinishedState(_sprintContext)); 
    }
    
    public void CreateSprintReview(string description)
    {
        throw new InvalidOperationException("Cannot create a sprint review before finishing the sprint!");
    }
    
    public void StartRelease(User user)
    {
        throw new InvalidOperationException("Cannot start a release before finishing the sprint!");
    }
}