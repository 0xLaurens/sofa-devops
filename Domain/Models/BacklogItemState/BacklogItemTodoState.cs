using Domain.Interfaces;

namespace Domain.Models;

public class BacklogItemTodoState(IBacklogItemContext context) : IBacklogItemState
{
    public void SetTodo()
    {
        throw new InvalidOperationException("Backlog item is already in Todo state.");
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
        context.SetState(new BacklogItemDoneState(context));
    }
}