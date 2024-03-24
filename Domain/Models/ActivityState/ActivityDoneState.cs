using Domain.Interfaces;

namespace Domain.Activity;

public class ActivityDoneState(IActivityContext context) : IActivityState
{
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
    
    public override string ToString()
    {
        return "Done";
    }
}