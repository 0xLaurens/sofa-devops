using Domain.Interfaces;

namespace Domain.Activity;

public class ActivityTestingState : IActivityState
{
    private IActivityContext _context;

    public ActivityTestingState(IActivityContext context)
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
        throw new InvalidOperationException("Already testing this activity!");
    }

    public void SetTested()
    {
        _context.SetState(new ActivityTestedState(_context));
    }

    public void SetDone()
    {
        throw new InvalidOperationException("Set the activity state to Tested first!");
    }

}