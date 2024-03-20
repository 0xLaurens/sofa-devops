using Domain.Interfaces;

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
        throw new InvalidOperationException("Activity is already done!");
    }

    public void SetDoing()
    {
        throw new InvalidOperationException("Activity is already done!");
    }

    public void SetReadyForTesting()
    {
        throw new InvalidOperationException("Activity is already done!");
    }

    public void SetTesting()
    {
        throw new InvalidOperationException("Activity is already done!");
    }

    public void SetTested()
    {
        throw new InvalidOperationException("Activity is already done!");
    }

    public void SetDone()
    {
        throw new InvalidOperationException("Activity is already done!");
    }

}