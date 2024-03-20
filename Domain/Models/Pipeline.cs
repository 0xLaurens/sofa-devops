using Domain.Interfaces;

namespace Domain.Models;

public class Pipeline
{
    private Release _release;
    private Source _source;
    private IPipelinePhase _pipelinePhase;
}