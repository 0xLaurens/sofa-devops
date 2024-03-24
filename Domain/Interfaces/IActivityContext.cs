using Domain.Models;

namespace Domain.Interfaces;

public interface IActivityContext 
{
    public void SetState(IActivityState state);
    public IActivityState GetState();

    public void Subscribe(ISubscriber listener);

    public void Unsubscribe(ISubscriber listener);

    public void Notify();

    public User getUser();

    

    public BacklogItem GetBacklogItem();


}