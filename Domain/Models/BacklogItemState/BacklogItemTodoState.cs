using Domain.Interfaces;

namespace Domain.Models;

public class BacklogItemTodoState(IBacklogItemContext context) : IBacklogItemState
{
    private IBacklogItemContext _context = context;

    public void SetTodo()
    {
        throw new InvalidOperationException("Backlog item is already in Todo state.");
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
        _context.SetState(new BacklogItemDoneState(_context));
    }
}