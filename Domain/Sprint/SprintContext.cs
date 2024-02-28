namespace Domain.Sprint;

public class SprintContext: ISprintContext
{
    private ISprintState _state;
    
    public void SetState(ISprintState state)
    {
        _state = state;
    }

    public ISprintState GetState()
    {
        return _state;
    }
}