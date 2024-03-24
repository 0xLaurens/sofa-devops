using Domain.Models;
using Domain.Models.PipelinePhase;
using Moq;

namespace Test;

//TC27: pipeline
[TestFixture]
public class PipelineTests
{
    [Test]
    public void ExecutePipeline_CallsCompositeTree_WhenPipelineExists()
    {
        // act
        var pipeline = new Pipeline();
        var buildPhase = new BuildPhase("Build frontend");
        var testPhase = new Mock<TestPhase>("Test frontend");
        var deployPhase = new Mock<DeploymentPhase>("Deploy frontend");
        var packagePhase = new Mock<PackagePhase>("Package frontend");
        var utilityPhase = new Mock<UtilityPhase>("Utility frontend");
        var analysisPhase = new Mock<AnalysisPhase>("Analyze codebase");

        // arrange

        buildPhase.AddPhase(testPhase.Object);
        buildPhase.AddPhase(analysisPhase.Object);
        buildPhase.AddPhase(deployPhase.Object);
        buildPhase.AddPhase(packagePhase.Object);
        buildPhase.AddPhase(utilityPhase.Object);
        
        pipeline.SetPipeline(buildPhase);

        // assert
        Assert.That(() => pipeline.ExecutePipeline(), Throws.Nothing);
        testPhase.Verify(x => x.Execute(), Times.Once);
        analysisPhase.Verify(x => x.Execute(), Times.Once);
        deployPhase.Verify(x => x.Execute(), Times.Once);
        packagePhase.Verify(x => x.Execute(), Times.Once);
        utilityPhase.Verify(x => x.Execute(), Times.Once);
    }

    [Test]
    public void ExecutePipeline_CallsCompositeTree_WhenPipelineExistsWithMultipleLevels()
    {
        // act
        var pipeline = new Pipeline();
        var buildPhase = new BuildPhase("Build frontend");
        var testPhase = new TestPhase("Test frontend");
        var deployPhase = new Mock<DeploymentPhase>("Deploy frontend"); 

        // arrange

        buildPhase.AddPhase(testPhase);
        testPhase.AddPhase(deployPhase.Object);
        pipeline.SetPipeline(buildPhase);

        // assert
        Assert.That(() => pipeline.ExecutePipeline(), Throws.Nothing);
        deployPhase.Verify(x => x.Execute(), Times.Once);
    }

    [Test]
    public void ExecutePipeline_ThrowsNoError_WhenPipelineEmpty()
    {
        // act
        var pipeline = new Pipeline();
        var buildPhase = new BuildPhase("Building frontend");
        var testPhase = new TestPhase("Testing frontend");
        var deployPhase = new DeploymentPhase("Deploying frontend");

        // arrange
        buildPhase.AddPhase(testPhase);
        testPhase.AddPhase(deployPhase);

        // assert
        // check whether a function was called
        Assert.That(() => pipeline.ExecutePipeline(), Throws.Nothing);
    }
}