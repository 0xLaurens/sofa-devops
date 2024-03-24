using Domain.Interfaces;

namespace Domain.Models;

public class BacklogItemDoingState(IBacklogItemContext context): IBacklogItemState
{
    private IBacklogItemContext _context = context;

    public void SetTodo()
    {
        _context.SetState(new BacklogItemTodoState(_context));
    }

    public void SetDoing()
    {
        throw new InvalidOperationException("Item is already in Doing state");
    }

    public void SetReadyForTesting()
    {
        _context.SetState(new BacklogItemReadyForTestingState(_context));
    }

    public void SetTesting()
    {
        _context.SetState(new BacklogItemTestingState(_context));
    }

    public void SetTested()
    {
        _context.SetState(new BacklogItemTestedState(_context));
    }

    public void SetDone()
    {
        _context.SetState(new BacklogItemDoneState(_context));
    }
}