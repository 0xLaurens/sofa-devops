namespace Domain.Sprint;

public interface IActivityState
{
    // Todo
    public void SetTodo();
    // Doing
    public void SetDoing();
    // Ready
    public void SetReady();
    // Testing
    public void SetTesting();
    // Tested
    public void SetTested();
    // Done
    public void SetDone();
}