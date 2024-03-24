using Domain.Interfaces;
using Domain.Models;
using Moq;

namespace Test;

[TestFixture]
public class BacklogItemDoneState
{
    [Test]
    public void SetTodo_WhenInvoked_SetsStateToTodo()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        var state = new Domain.Models.BacklogItemDoneState(context.Object);
        
        // Act
        state.SetTodo();
        
        // Assert
        context.Verify(x => x.SetState(It.IsAny<Domain.Models.BacklogItemTodoState>()));
    }
    
    [Test]
    public void SetDoing_WhenInvoked_SetsStateToDoing()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        var state = new Domain.Models.BacklogItemDoneState(context.Object);
        
        // Act
        state.SetDoing();
        
        // Assert
        context.Verify(x => x.SetState(It.IsAny<Domain.Models.BacklogItemDoingState>()));
    }
    
    [Test]
    public void SetReadyForTesting_WhenInvoked_SetsStateToReadyForTesting()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        var state = new Domain.Models.BacklogItemDoneState(context.Object);
        
        // Act
        state.SetReadyForTesting();
        
        // Assert
        context.Verify(x => x.SetState(It.IsAny<Domain.Models.BacklogItemReadyForTestingState>()));
    }
    
    [Test]
    public void SetTesting_WhenInvoked_SetsStateToTesting()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        var state = new Domain.Models.BacklogItemDoneState(context.Object);
        
        // Act
        state.SetTesting();
        
        // Assert
        context.Verify(x => x.SetState(It.IsAny<Domain.Models.BacklogItemTestingState>()));
    }
    
    [Test]
    public void SetTested_WhenInvoked_SetsStateToTested()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        var state = new Domain.Models.BacklogItemDoneState(context.Object);
        
        // Act
        state.SetTested();
        
        // Assert
        context.Verify(x => x.SetState(It.IsAny<Domain.Models.BacklogItemTestedState>()));
    }
    
    [Test]
    public void SetDone_WhenInvoked_ThrowsInvalidOperationException()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        var state = new Domain.Models.BacklogItemDoneState(context.Object);
        
        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => state.SetDone());
        
        // Assert
        Assert.That(ex.Message, Is.EqualTo("Backlog item is already in Done state."));
    }
}