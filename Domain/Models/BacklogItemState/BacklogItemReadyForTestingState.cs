using Domain.Interfaces;

namespace Domain.Models;

public class BacklogItemReadyForTestingState(IBacklogItemContext context) : IBacklogItemState
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
        throw new InvalidOperationException("Item is already in Ready For Testing state");
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