using Domain.Sprint;

namespace Domain;

public interface IActivityContext 
{
    public void SetState(IActivityState state);
    public IActivityState GetState();
}