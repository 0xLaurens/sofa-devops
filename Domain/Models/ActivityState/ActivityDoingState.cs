using Domain.Interfaces;

namespace Domain.Activity;

public class ActivityDoingState: IActivityState
{
    private IActivityContext _context;
    
    public ActivityDoingState(IActivityContext context)
    {
        _context = context;
    }

  

    public void SetTodo()
    {
        
        _context.SetState(new ActivityTodoState(_context));
    }

    public void SetDoing()
    {
        throw new InvalidOperationException("Already doing this activity!");
    }

    public void SetReadyForTesting()
    {
        
        _context.SetState(new ActivityReadyForTestingState(_context));
    }

    public void SetTesting()
    {
        //_context.SetState(new ActivityTestingState(_context));
        throw new InvalidOperationException("Set the activity state to Ready For Testing first!");
    }

    public void SetTested()
    {
        throw new InvalidOperationException("Set the activity state to Ready For Testing first!");
    }

    public void SetDone()
    {
        throw new InvalidOperationException("Set the activity state to Ready For Testing first!");
    }

    public override string ToString()
    {
        return "Doing";
    }
}