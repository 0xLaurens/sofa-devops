using Domain.Sprint;

namespace Domain.Activity;

public class ActivityDoneState : IActivityState
{
    private IActivityContext _context;

    public ActivityDoneState(IActivityContext context)
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
        _context.SetState(new ActivityReadyState(_context));
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
        throw new InvalidOperationException("Activity is already done!");
    }

}