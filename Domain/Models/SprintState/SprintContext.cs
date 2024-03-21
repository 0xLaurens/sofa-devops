using Domain.Interfaces;

namespace Domain.Models.SprintState;

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