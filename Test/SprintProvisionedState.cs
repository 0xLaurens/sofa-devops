using Domain.Models;
using Domain.Models.SprintState;

namespace Test;

[TestFixture]
public class SprintProvisionedState
{
    [Test]
    public void StartSprint_SetsStateToSprintActiveState()
    {
        // Arrange
        var sprintContext = new Sprint("First sprint", DateTime.Now, DateTime.Now.AddDays(7));
        sprintContext.SetState(new Domain.Models.SprintState.SprintProvisionedState(sprintContext));
        
        // Act
        sprintContext.GetState().StartSprint();
        
        // Assert
        Assert.That(sprintContext.GetState(), Is.InstanceOf<Domain.Models.SprintState.SprintActiveState>());
    }
    
    [Test]
    public void FinishSprint_ThrowsInvalidOperationException()
    {
        // Arrange
        var sprintContext = new Sprint("First sprint", DateTime.Now, DateTime.Now.AddDays(7));
        sprintContext.SetState(new Domain.Models.SprintState.SprintProvisionedState(sprintContext));
        
        // Act
        var exception = Assert.Throws<InvalidOperationException>(() => sprintContext.GetState().FinishSprint());
        
        // Assert
        Assert.That(exception?.Message, Is.EqualTo("Sprint has not been started yet!"));
    }
    
    //TC15: create sprint review
    [Test]
    public void CreateSprintReview_ThrowsInvalidOperationException()
    {
        // Arrange
        var sprintContext = new Sprint("First sprint", DateTime.Now, DateTime.Now.AddDays(7));
        sprintContext.SetState(new Domain.Models.SprintState.SprintProvisionedState(sprintContext));
        
        // Act
        var exception = Assert.Throws<InvalidOperationException>(() => sprintContext.GetState().CreateSprintReview("Review"));
        
        // Assert
        Assert.That(exception?.Message, Is.EqualTo("Sprint has not been started yet!"));
    }
}