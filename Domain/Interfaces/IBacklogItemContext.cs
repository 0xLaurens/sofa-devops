using Domain.Models;

namespace Domain.Interfaces;

public interface IBacklogItemContext
{
    public void SetState(IBacklogItemState state);
    public IBacklogItemState GetState();
    
    public IBacklogItemState? GetPreviousState();
    
    public void SetApprover(User user);
    public User? GetApprover();
}