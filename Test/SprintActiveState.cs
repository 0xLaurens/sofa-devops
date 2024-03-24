using Domain.Models.SprintState;

namespace Test;

[TestFixture]
public class SprintActiveState
{
    [Test]
    public void StartSprint_ThrowsInvalidOperationException()
    {
        // Arrange
        var sprintContext = new SprintContext();
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
        var sprintContext = new SprintContext();
        sprintContext.SetState(new Domain.Models.SprintState.SprintActiveState(sprintContext));
        
        // Act
        sprintContext.GetState().FinishSprint();
        
        // Assert
        Assert.That(sprintContext.GetState(), Is.InstanceOf<Domain.Models.SprintState.SprintFinishedState>());
    }
}