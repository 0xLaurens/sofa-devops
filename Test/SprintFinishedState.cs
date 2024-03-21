using Domain.Models.SprintState;

namespace Test;

[TestFixture]
public class SprintFinishedState
{
    [Test]
    public void StartSprint_ThrowsInvalidOperationException()
    {
        // Arrange
        var sprintContext = new SprintContext();
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
        var sprintContext = new SprintContext();
        sprintContext.SetState(new Domain.Models.SprintState.SprintFinishedState(sprintContext));
        
        // Act
        var exception = Assert.Throws<InvalidOperationException>(() => sprintContext.GetState().FinishSprint());
        
        // Assert
        Assert.That(exception?.Message, Is.EqualTo("Sprint has already finished!"));
    }
}