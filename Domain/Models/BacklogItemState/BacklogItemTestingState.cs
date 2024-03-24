using Domain.Interfaces;

namespace Domain.Models;

public class BacklogItemTestingState(IBacklogItemContext context): IBacklogItemState
{
    public void SetTodo()
    {
        context.SetState(new BacklogItemTodoState(context));
    }

    public void SetDoing()
    {
        context.SetState(new BacklogItemDoingState(context));
    }

    public void SetReadyForTesting()
    {
        context.SetState(new BacklogItemReadyForTestingState(context));
    }

    public void SetTesting()
    {
        throw new InvalidOperationException("Item is already in Testing state");
    }

    public void SetTested()
    {
        context.SetState(new BacklogItemTestedState(context));
    }

    public void SetDone()
    {
        context.SetState(new BacklogItemDoneState(context));
    }
    
}