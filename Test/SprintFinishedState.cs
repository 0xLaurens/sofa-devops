using Domain.Models;
using Domain.Models.SprintState;

namespace Test;

[TestFixture]
public class SprintFinishedState
{
    [Test]
    public void StartSprint_ThrowsInvalidOperationException()
    {
        // Arrange
        var sprintContext = new Sprint("First sprint", DateTime.Now, DateTime.Now.AddDays(7));
        sprintContext.SetState(new Domain.Models.SprintState.SprintFinishedState(sprintContext));
        
        // Act
        var exception = Assert.Throws<InvalidOperationException>(() => sprintContext.GetState().StartSprint());
        
        // Assert
        Assert.That(exception?.Message, Is.EqualTo("Cannot start a finished sprint!"));
    }
    
    [Test]
    public void FinishSprint_ThrowsInvalidOperationException()
    {
        // Arrange
        var sprintContext = new Sprint("First sprint", DateTime.Now, DateTime.Now.AddDays(7));
        sprintContext.SetState(new Domain.Models.SprintState.SprintFinishedState(sprintContext));
        
        // Act
        var exception = Assert.Throws<InvalidOperationException>(() => sprintContext.GetState().FinishSprint());
        
        // Assert
        Assert.That(exception?.Message, Is.EqualTo("Sprint has already finished!"));
    }
    
    [Test]
    public void CreateSprintReview_CreatesReview()
    {
        // Arrange
        var sprintContext = new Sprint("First sprint", DateTime.Now, DateTime.Now.AddDays(7));
        sprintContext.SetState(new Domain.Models.SprintState.SprintFinishedState(sprintContext));
        
        // Act
        sprintContext.GetState().CreateSprintReview("Review");
        
        // Assert
        Assert.That(sprintContext.GetState(), Is.InstanceOf<Domain.Models.SprintState.SprintFinishedState>());
    }
}