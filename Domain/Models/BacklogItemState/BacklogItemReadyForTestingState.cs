using Domain.Interfaces;

namespace Domain.Models;

public class BacklogItemReadyForTestingState(IBacklogItemContext context) : IBacklogItemState
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
        throw new InvalidOperationException("Item is already in Ready For Testing state");
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