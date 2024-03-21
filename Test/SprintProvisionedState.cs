using Domain.Models.SprintState;

namespace Test;

[TestFixture]
public class SprintProvisionedState
{
    [Test]
    public void StartSprint_SetsStateToSprintActiveState()
    {
        // Arrange
        var sprintContext = new SprintContext();
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
        var sprintContext = new SprintContext();
        sprintContext.SetState(new Domain.Models.SprintState.SprintProvisionedState(sprintContext));
        
        // Act
        var exception = Assert.Throws<InvalidOperationException>(() => sprintContext.GetState().FinishSprint());
        
        // Assert
        Assert.That(exception?.Message, Is.EqualTo("Sprint has not been started yet!"));
    }
}