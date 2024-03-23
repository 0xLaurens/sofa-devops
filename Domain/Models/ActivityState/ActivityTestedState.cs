using Domain.Interfaces;

namespace Domain.Activity;

public class ActivityTestedState : IActivityState
{
    private IActivityContext _context;


    public ActivityTestedState(IActivityContext context)
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
       
        _context.SetState(new ActivityReadyForTestingState(_context));
    }

    public void SetTesting()
    {
      
        _context.SetState(new ActivityTestingState(_context));
    }

    public void SetTested()
    {
        throw new InvalidOperationException("Activity was already tested!");
    }

    public void SetDone()
    {
      
        _context.SetState(new ActivityDoneState(_context));
    }

}