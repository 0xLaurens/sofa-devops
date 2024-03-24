using Domain.Interfaces;

namespace Domain.Activity;

public class ActivityTodoState(IActivityContext context) : IActivityState
{
    public void SetTodo()
    {
        throw new InvalidOperationException("Activity is already in the todo");
    }

    public void SetDoing()
    {
        context.SetState(new ActivityDoingState(context));
    }

    public void SetReadyForTesting()
    {
        throw new InvalidOperationException("Set the activity state to Doing first!");
    }

    public void SetTesting()
    {
        throw new InvalidOperationException("Set the activity state to Doing first!");
    }

    public void SetTested()
    {
        throw new InvalidOperationException("Set the activity state to Doing first!");
    }

    public void SetDone()
    {
        throw new InvalidOperationException("Set the activity state to Doing first!");
    }
    
    public override string ToString()
    {
        return "Todo";
    }
}