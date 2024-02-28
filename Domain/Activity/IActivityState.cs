namespace Domain.Sprint;

public interface IActivityState
{
    // Todo
    public void SetTodo(IActivityContext context);
    // Doing
    public void SetDoing(IActivityContext context);
    // Ready
    public void SetReady(IActivityContext context);
    // Testing
    public void SetTesting(IActivityContext context);
    // Tested
    public void SetTested(IActivityContext context);
    // Done
    public void SetDone(IActivityContext context);
}