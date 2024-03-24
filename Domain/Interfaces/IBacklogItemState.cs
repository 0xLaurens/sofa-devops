using Domain.Models;

namespace Domain.Interfaces;

public interface IBacklogItemState
{
    public void SetTodo();
    public void SetDoing();
    public void SetReadyForTesting();
    public void SetTesting();
    public void SetTested();
    public void SetDone();
}