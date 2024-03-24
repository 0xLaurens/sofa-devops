using Domain.Interfaces;

namespace Domain.Models;

public class BacklogItemDoingState(IBacklogItemContext context): IBacklogItemState
{
    public void SetTodo()
    {
        context.SetState(new BacklogItemTodoState(context));
    }

    public void SetDoing()
    {
        throw new InvalidOperationException("Item is already in Doing state");
    }

    public void SetReadyForTesting()
    {
        context.SetState(new BacklogItemReadyForTestingState(context));
    }

    public void SetTesting()
    {
        context.SetState(new BacklogItemTestingState(context));
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