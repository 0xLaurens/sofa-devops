using Domain.Interfaces;

namespace Domain.Activity;

public class ActivityReadyForTestingState(IActivityContext context) : IActivityState
{
    public void SetTodo()
    {
        context.SetState(new ActivityTodoState(context));
    }

    public void SetDoing()
    {
        context.SetState(new ActivityDoingState(context));
    }

    public void SetReadyForTesting()
    {
        throw new InvalidOperationException("Activity is already ready for testing!");
    }

    public void SetTesting()
    {
        context.SetState(new ActivityTestingState(context));
    }

    public void SetTested()
    {
        throw new InvalidOperationException("Set the activity state to Testing first!");
    }

    public void SetDone()
    {
        throw new InvalidOperationException("Set the activity state to Testing first!");
    }

    public override string ToString()
    {
        return "Ready For Testing";
    }
}