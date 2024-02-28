namespace Domain.Sprint;

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
}