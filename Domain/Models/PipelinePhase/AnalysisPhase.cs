using Domain.Interfaces;

namespace Domain.Models.PipelinePhase;

public class AnalysisPhase(string taskName) : BasePipelinePhase(taskName)
{
    public override void Execute()
    {
        Console.WriteLine($"Running the {this}" );
        Console.WriteLine($"{this} has {Children.Count} child phases: {string.Join(", ", Children)}");
        
        foreach (var phase in Children)
        {
           phase.Execute(); 
        }
    }
}