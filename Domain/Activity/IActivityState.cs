namespace Domain.Sprint;

public interface IActivityState
{
    public void Accept(IVisitor visitor);
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