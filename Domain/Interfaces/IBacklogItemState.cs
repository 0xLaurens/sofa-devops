using Domain.Models;

namespace Domain.Interfaces;

public interface IBacklogItemState
{
    public void SetTodo(User user);
    public void SetDoing(User user);
    public void SetReadyForTesting(User user);
    public void SetTesting(User user);
    public void SetTested(User user);
    public void SetDone(User user);
}