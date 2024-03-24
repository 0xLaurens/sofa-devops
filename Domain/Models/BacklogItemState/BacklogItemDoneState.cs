using Domain.Interfaces;

namespace Domain.Models;

public class BacklogItemDoneState(IBacklogItemContext context) : IBacklogItemState
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
        context.SetState(new BacklogItemTestingState(context));
    }

    public void SetTested()
    {
        context.SetState(new BacklogItemTestedState(context));
    }

    public void SetDone()
    {
        throw new InvalidOperationException("Backlog item is already in Done state.");
    }
}