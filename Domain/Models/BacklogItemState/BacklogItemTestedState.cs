using Domain.Interfaces;
using Domain.Models.UserRoles;

namespace Domain.Models;

public class BacklogItemTestedState(IBacklogItemContext context) : IBacklogItemState
{
    private IBacklogItemContext _context = context;

    public void LeadDeveloperGuard()
    {
        if (_context.GetApprover() == null)
        {
            throw new InvalidOperationException("No approver set for this item.");
        }
        
        if (_context.GetApprover()?.GetType() != typeof(LeadDeveloper))
        {
            throw new InvalidOperationException("Only Lead Developer can approve the tested phase.");
        }
    }

    public void SetTodo()
    {
        LeadDeveloperGuard();
        _context.SetState(new BacklogItemTodoState(_context));
    }

    public void SetDoing()
    {
        LeadDeveloperGuard();
        _context.SetState(new BacklogItemDoingState(_context));
    }

    public void SetReadyForTesting()
    {
        LeadDeveloperGuard();
        _context.SetState(new BacklogItemReadyForTestingState(_context));
    }

    public void SetTesting()
    {
        LeadDeveloperGuard();
        _context.SetState(new BacklogItemTestingState(_context));
    }

    public void SetTested()
    {
        throw new InvalidOperationException("Item is already in Tested state");
    }

    public void SetDone()
    {
        LeadDeveloperGuard();
        _context.SetState(new BacklogItemDoneState(_context));
    }
}