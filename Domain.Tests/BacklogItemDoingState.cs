using Domain.Interfaces;
using Domain.Models;
using Moq;

namespace Test;

[TestFixture]
public class BacklogItemDoingState
{
    [Test]
    public void SetTodo_WhenInvoked_SetsStateToTodo()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        var state = new Domain.Models.BacklogItemDoingState(context.Object);
        
        // Act
        state.SetTodo();
        
        // Assert
        context.Verify(x => x.SetState(It.IsAny<Domain.Models.BacklogItemTodoState>()));
    }
    
    [Test]
    public void SetDoing_WhenInvoked_ThrowsException()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        var state = new Domain.Models.BacklogItemDoingState(context.Object);
        
        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => state.SetDoing());
        
        // Assert
        Assert.That(ex.Message, Is.EqualTo("Item is already in Doing state"));
    }
    
    [Test]
    public void SetReadyForTesting_WhenInvoked_SetsStateToReadyForTesting()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        var state = new Domain.Models.BacklogItemDoingState(context.Object);
        
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
        var state = new Domain.Models.BacklogItemDoingState(context.Object);
        
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
        var state = new Domain.Models.BacklogItemDoingState(context.Object);
        
        // Act
        state.SetTested();
        
        // Assert
        context.Verify(x => x.SetState(It.IsAny<Domain.Models.BacklogItemTestedState>()));
    }
    
    [Test]
    public void SetDone_WhenInvoked_SetsStateToDone()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        var state = new Domain.Models.BacklogItemDoingState(context.Object);
        
        // Act
        state.SetDone();
        
        // Assert
        context.Verify(x => x.SetState(It.IsAny<Domain.Models.BacklogItemDoneState>()));
    }
}