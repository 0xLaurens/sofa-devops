using Domain.Interfaces;
using Domain.Models.UserRoles;

namespace Domain.Models;

public class BacklogItemTestedState(IBacklogItemContext context) : IBacklogItemState
{
    public void LeadDeveloperGuard()
    {
        if (context.GetApprover() == null)
        {
            throw new InvalidOperationException("No approver set for this item.");
        }
        
        if (context.GetApprover()?.GetType() != typeof(LeadDeveloper))
        {
            throw new InvalidOperationException("Only Lead Developer can approve the tested phase.");
        }
    }

    public void SetTodo()
    {
        LeadDeveloperGuard();
        context.SetState(new BacklogItemTodoState(context));
    }

    public void SetDoing()
    {
        LeadDeveloperGuard();
        context.SetState(new BacklogItemDoingState(context));
    }

    public void SetReadyForTesting()
    {
        LeadDeveloperGuard();
        context.SetState(new BacklogItemReadyForTestingState(context));
    }

    public void SetTesting()
    {
        LeadDeveloperGuard();
        context.SetState(new BacklogItemTestingState(context));
    }

    public void SetTested()
    {
        throw new InvalidOperationException("Item is already in Tested state");
    }

    public void SetDone()
    {
        LeadDeveloperGuard();
        context.SetState(new BacklogItemDoneState(context));
    }
}