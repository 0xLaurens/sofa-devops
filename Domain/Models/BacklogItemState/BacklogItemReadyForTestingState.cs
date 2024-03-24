using Domain.Interfaces;

namespace Domain.Models;

public class BacklogItemReadyForTestingState(IBacklogItemContext context) : IBacklogItemState
{
    private IBacklogItemContext _context = context;

    public void SetTodo(User user)
    {
        throw new NotImplementedException();
    }

    public void SetDoing(User user)
    {
        throw new NotImplementedException();
    }

    public void SetReadyForTesting(User user)
    {
        throw new NotImplementedException();
    }

    public void SetTesting(User user)
    {
        throw new NotImplementedException();
    }

    public void SetTested(User user)
    {
        throw new NotImplementedException();
    }

    public void SetDone(User user)
    {
        throw new NotImplementedException();
    }
}