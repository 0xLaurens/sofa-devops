namespace Domain.Interfaces;

public interface IActivityState
{

    // Todo
    public void SetTodo();
    // Doing
    public void SetDoing();
    // Ready
    public void SetReadyForTesting();
    // Testing
    public void SetTesting();
    // Tested
    public void SetTested();
    // Done
    public void SetDone();
}