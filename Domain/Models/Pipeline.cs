
using Domain.Models.PipelinePhase;

namespace Domain.Models;

public class Pipeline
{
    private Release _release;
    private Source _source;
    private BasePipelinePhase? _pipelinePhase;

    public void SetPipeline(BasePipelinePhase? pipelinePhase)
    {
        _pipelinePhase = pipelinePhase;
    }

    public void DeletePipeline()
    {
        _pipelinePhase = null;
    }

    public void ExecutePipeline()
    {
        _pipelinePhase?.Execute();
    }
}