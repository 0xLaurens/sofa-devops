using Domain.Interfaces;

namespace Domain.Activity;

public class ActivityTestedState(IActivityContext context) : IActivityState
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
      
        context.SetState(new ActivityTestingState(context));
    }

    public void SetTested()
    {
        throw new InvalidOperationException("Activity was already tested!");
    }

    public void SetDone()
    {
      
        context.SetState(new ActivityDoneState(context));
    }
    
    public override string ToString()
    {
        return "Tested";
    }
}