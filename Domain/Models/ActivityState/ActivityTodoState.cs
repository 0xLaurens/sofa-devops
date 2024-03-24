using Domain.Interfaces;

namespace Domain.Activity;

public class ActivityTodoState: IActivityState
{
    private IActivityContext _context;
 
    public ActivityTodoState(IActivityContext context)
    {
        _context = context;
    
    }

   

    public void SetTodo()
    {
        throw new InvalidOperationException("Activity is already in the todo");
    }

    public void SetDoing()
    {
     
        _context.SetState(new ActivityDoingState(_context));
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

}