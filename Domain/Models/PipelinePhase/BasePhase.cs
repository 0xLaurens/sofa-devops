namespace Domain.Models.PipelinePhase;

public abstract class BasePipelinePhase(string taskName)
{
    protected readonly List<BasePipelinePhase> Children = [];

    public virtual string GetName()
    {
        return taskName;
    }
    
    public abstract void Execute();

    // virtual allows override to allow for possible changes
    public void AddPhase(BasePipelinePhase phase)
    {
        Children.Add(phase);
    }

    // virtual allows override to allow for possible changes in implementation
    public void RemovePhase(BasePipelinePhase phase)
    {
        Children.Remove(phase);
    }

    public override string ToString()
    {
        return taskName;
    }
}