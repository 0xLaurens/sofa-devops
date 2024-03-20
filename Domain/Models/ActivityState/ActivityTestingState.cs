using Domain.Interfaces;

namespace Domain.Activity;

public class ActivityTestingState : IActivityState
{
    private IActivityContext _context;

    public ActivityTestingState(IActivityContext context)
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
        _context.SetState(new ActivityDoingState(_context));
    }

    public void SetReady()
    {
        _context.SetState(new ActivityReadyState(_context));
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
        _context.SetState(new ActivityDoneState(_context));
    }

}