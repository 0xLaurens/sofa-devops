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
        var testPhase = new Mock<TestPhase>("Domain.Tests frontend");
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
        var testPhase = new TestPhase("Domain.Tests frontend");
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

    [Test]
    public void ExecutePipeline_ThrowsNoError_WhenPipelineNull()
    {
        // act
        var pipeline = new Pipeline();

        // assert
        // check whether a function was called
        Assert.That(() => pipeline.ExecutePipeline(), Throws.Nothing);
    }

    [Test]
    public void DeployPhase_ForwardedToNextPhase_WhenDeployPhaseExists()
    {
        // act
        var pipeline = new Pipeline();
        var buildPhase = new BuildPhase("Building frontend");
        var deployPhase = new DeploymentPhase("Deploying frontend");

        // arrange
        deployPhase.AddPhase(buildPhase);

        // assert
        Assert.That(() => pipeline.ExecutePipeline(), Throws.Nothing);
        deployPhase.Execute();
    }
    
    [Test]
    public void AnalysisPhase_ForwardedToNextPhase_WhenAnalysisPhaseExists()
    {
        // act
        var pipeline = new Pipeline();
        var buildPhase = new BuildPhase("Building frontend");
        var analysisPhase = new AnalysisPhase("Analyzing frontend");

        // arrange
        analysisPhase.AddPhase(buildPhase);

        // assert
        Assert.That(() => pipeline.ExecutePipeline(), Throws.Nothing);
        analysisPhase.Execute();
    }
    
    [Test]
    public void PackagePhase_ForwardedToNextPhase_WhenPackagePhaseExists()
    {
        // act
        var pipeline = new Pipeline();
        var buildPhase = new BuildPhase("Building frontend");
        var packagePhase = new PackagePhase("Packaging frontend");

        // arrange
        packagePhase.AddPhase(buildPhase);

        // assert
        Assert.That(() => pipeline.ExecutePipeline(), Throws.Nothing);
        packagePhase.Execute();
    }
    
    [Test]
    public void UtilityPhase_ForwardedToNextPhase_WhenUtilityPhaseExists()
    {
        // act
        var pipeline = new Pipeline();
        var buildPhase = new BuildPhase("Building frontend");
        var utilityPhase = new UtilityPhase("Utility frontend");

        // arrange
        utilityPhase.AddPhase(buildPhase);

        // assert
        Assert.That(() => pipeline.ExecutePipeline(), Throws.Nothing);
        utilityPhase.Execute();
    }
    
    [Test]
    public void TestPhase_ForwardedToNextPhase_WhenTestPhaseExists()
    {
        // act
        var pipeline = new Pipeline();
        var buildPhase = new BuildPhase("Building frontend");
        var testPhase = new TestPhase("Testing frontend");

        // arrange
        testPhase.AddPhase(buildPhase);

        // assert
        Assert.That(() => pipeline.ExecutePipeline(), Throws.Nothing);
        testPhase.Execute();
    }
    
    [Test]
    public void BuildPhase_ForwardedToNextPhase_WhenBuildPhaseExists()
    {
        // act
        var pipeline = new Pipeline();
        var buildPhase = new BuildPhase("Building frontend");

        // assert
        Assert.That(() => pipeline.ExecutePipeline(), Throws.Nothing);
        buildPhase.Execute();
    }
    
    [Test]
    public void RemovePhase_FromPipeline_WhenPhaseExists()
    {
        // act
        var pipeline = new Pipeline();
        var buildPhase = new BuildPhase("Building frontend");
        var testPhase = new TestPhase("Testing frontend");

        // arrange
        buildPhase.AddPhase(testPhase);
        
        pipeline.SetPipeline(buildPhase);

        // assert
        Assert.That(() => buildPhase.RemovePhase(testPhase), Throws.Nothing);
    }
}