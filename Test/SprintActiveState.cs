using Domain.Models;
using Domain.Models.SprintState;
using Domain.Models.UserRoles;

namespace Test;

[TestFixture]
public class SprintActiveState
{
    [Test]
    public void StartSprint_ThrowsInvalidOperationException()
    {
        // Arrange
        var sprintContext = new Sprint("First sprint", DateTime.Now, DateTime.Now.AddDays(7));
        sprintContext.SetState(new Domain.Models.SprintState.SprintActiveState(sprintContext));
        
        // Act
        var exception = Assert.Throws<InvalidOperationException>(() => sprintContext.GetState().StartSprint());
        
        // Assert
        Assert.That(exception?.Message, Is.EqualTo("Sprint is already active!"));
    }
    
    [Test]
    public void FinishSprint_SetsStateToSprintFinishedState()
    {
        // Arrange
        var sprintContext = new Sprint("First sprint", DateTime.Now, DateTime.Now.AddDays(7));
        sprintContext.SetState(new Domain.Models.SprintState.SprintActiveState(sprintContext));
        
        // Act
        sprintContext.GetState().FinishSprint();
        
        // Assert
        Assert.That(sprintContext.GetState(), Is.InstanceOf<Domain.Models.SprintState.SprintFinishedState>());
    }
    
    //TC15: create sprint review
    [Test]
    public void CreateSprintReview_ThrowsInvalidOperationException()
    {
        // Arrange
        var sprintContext = new Sprint("First sprint", DateTime.Now, DateTime.Now.AddDays(7));
        sprintContext.SetState(new Domain.Models.SprintState.SprintActiveState(sprintContext));
        
        // Act
        var exception = Assert.Throws<InvalidOperationException>(() => sprintContext.GetState().CreateSprintReview("Review"));
        
        // Assert
        Assert.That(exception?.Message, Is.EqualTo("Cannot create a sprint review before finishing the sprint!"));
    }
    
    //TC17: start release
    [Test]
    public void StartRelease_ThrowsInvalidOperationException()
    {
        // Arrange
        var sprintContext = new Sprint("First sprint", DateTime.Now, DateTime.Now.AddDays(7));
        sprintContext.SetState(new Domain.Models.SprintState.SprintActiveState(sprintContext));
        
        // Act
        var exception = Assert.Throws<InvalidOperationException>(() => sprintContext.GetState().StartRelease(new ScrumMaster("John Doe", "john@gmail.com")));
        
        // Assert
        Assert.That(exception?.Message, Is.EqualTo("Cannot start a release before finishing the sprint!"));
    }
}