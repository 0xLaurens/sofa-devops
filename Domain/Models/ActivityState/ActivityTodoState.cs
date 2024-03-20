using Domain.Interfaces;

namespace Domain.Activity;

public class ActivityTodoState: IActivityState
{
    private IActivityContext _context;
    public ActivityTodoState(IActivityContext context)
    {
        _context = context;
    }

    public void Accept(IVisitor visitor)
    {
        throw new NotImplementedException();
    }

    public void SetTodo()
    {
        throw new InvalidOperationException("Activity is already in the todo");
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
        _context.SetState(new ActivityDoneState(_context));
    }

}