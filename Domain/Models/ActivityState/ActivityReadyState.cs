using Domain.Interfaces;

namespace Domain.Activity;

public class ActivityReadyState : IActivityState
{
    private IActivityContext _context;

    public ActivityReadyState(IActivityContext context)
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

    public void SetReady()
    {
        
        throw new InvalidOperationException("Activity is already ready!");
    }

    public void SetTesting()
    {
        _context.SetState(new ActivityTestingState(_context));
    }

    public void SetTested()
    {
        _context.SetState(new ActivityTestedState(_context));
    }

    public void SetDone()
    {
        _context.SetState(new ActivityDoneState(_context));
    }

}