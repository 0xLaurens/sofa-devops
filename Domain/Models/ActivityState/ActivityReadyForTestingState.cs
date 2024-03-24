using Domain.Interfaces;

namespace Domain.Activity;

public class ActivityReadyForTestingState : IActivityState
{
    private IActivityContext _context;


    public ActivityReadyForTestingState(IActivityContext context)
    {
        _context = context;
        
        
    }

   

    public void SetTodo()
    {
     
        _context.SetState(new ActivityTodoState(_context));
    }

    public void SetDoing()
    {
      
        _context.SetState(new ActivityDoingState(_context));
    }

    public void SetReadyForTesting()
    {
        
        throw new InvalidOperationException("Activity is already ready for testing!");
    }

    public void SetTesting()
    {
        
        _context.SetState(new ActivityTestingState(_context));
    }

    public void SetTested()
    {
        throw new InvalidOperationException("Set the activity state to Testing first!");
    }

    public void SetDone()
    {
        throw new InvalidOperationException("Set the activity state to Testing first!");
    }

}