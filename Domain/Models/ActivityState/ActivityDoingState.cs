using Domain.Interfaces;

namespace Domain.Activity;

public class ActivityDoingState: IActivityState
{
    private IActivityContext _context;
    public ActivityDoingState(IActivityContext context)
    {
        _context = context;
    }

    public void Accept(IVisitor visitor)
    {
        throw new NotImplementedException();
    }

    public void SetTodo()
    {
        _context.SetState(new ActivityTodoState(_context));
    }

    public void SetDoing()
    {
        throw new InvalidOperationException("Already doing this activity!");
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
        _context.SetState(new ActivityDoneState(_context));
    }
}