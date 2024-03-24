using Domain.Interfaces;

namespace Domain.Models;

public class BacklogItemTestingState(IBacklogItemContext context): IBacklogItemState
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
        throw new InvalidOperationException("Item is already in Testing state");
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