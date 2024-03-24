using Domain.Interfaces;

namespace Domain.Activity;

public class ActivityDoingState(IActivityContext context) : IActivityState
{
    public void SetTodo()
    {
        
        context.SetState(new ActivityTodoState(context));
    }

    public void SetDoing()
    {
        throw new InvalidOperationException("Already doing this activity!");
    }

    public void SetReadyForTesting()
    {
        
        context.SetState(new ActivityReadyForTestingState(context));
    }

    public void SetTesting()
    {
        throw new InvalidOperationException("Set the activity state to Ready For Testing first!");
    }

    public void SetTested()
    {
        throw new InvalidOperationException("Set the activity state to Ready For Testing first!");
    }

    public void SetDone()
    {
        throw new InvalidOperationException("Set the activity state to Ready For Testing first!");
    }

    public override string ToString()
    {
        return "Doing";
    }
}