using Domain.Interfaces;

namespace Domain.Activity;

public class ActivityTestingState(IActivityContext context) : IActivityState
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
        
        context.SetState(new ActivityReadyForTestingState(context));
    }

    public void SetTesting()
    {
        throw new InvalidOperationException("Already testing this activity!");
    }

    public void SetTested()
    {
        
        context.SetState(new ActivityTestedState(context));
    }

    public void SetDone()
    {
        throw new InvalidOperationException("Set the activity state to Tested first!");
    }

    public override string ToString()
    {
        return "Testing";
    }
}