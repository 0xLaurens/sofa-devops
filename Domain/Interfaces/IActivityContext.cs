namespace Domain.Interfaces;

public interface IActivityContext 
{
    public void SetState(IActivityState state);
    public IActivityState GetState();
}