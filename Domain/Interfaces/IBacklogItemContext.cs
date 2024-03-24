using Domain.Models;

namespace Domain.Interfaces;

public interface IBacklogItemContext
{
    public void SetState(IBacklogItemState state, User user);
    public IBacklogItemState GetState();
    
    public IBacklogItemState GetPreviousState();
}