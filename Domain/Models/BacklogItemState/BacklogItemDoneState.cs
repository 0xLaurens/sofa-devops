using Domain.Interfaces;

namespace Domain.Models;

public class BacklogItemDoneState(IBacklogItemContext context) : IBacklogItemState
{
    private IBacklogItemContext _context = context;

    public void SetTodo()
    {
        _context.SetState(new BacklogItemTodoState(_context));
    }

    public void SetDoing()
    {
        _context.SetState(new BacklogItemDoingState(_context));
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
        throw new InvalidOperationException("Backlog item is already in Done state.");
    }
}