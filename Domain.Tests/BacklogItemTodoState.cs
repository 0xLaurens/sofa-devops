using Domain.Interfaces;
using Moq;

namespace Test;

[TestFixture]
public class BacklogItemTodoState
{
    [Test]
    public void SetDoing_WhenInvoked_SetsStateToDoing()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        var state = new Domain.Models.BacklogItemTodoState(context.Object);
        
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
        var state = new Domain.Models.BacklogItemTodoState(context.Object);
        
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
        var state = new Domain.Models.BacklogItemTodoState(context.Object);
        
        // Act
        state.SetTesting();
        
        // Assert
        context.Verify(x => x.SetState(It.IsAny<Domain.Models.BacklogItemTestingState>()));
    }
    
    [Test]
    public void SetDone_WhenInvoked_SetsStateToDone()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        var state = new Domain.Models.BacklogItemTodoState(context.Object);
        
        // Act
        state.SetDone();
        
        // Assert
        context.Verify(x => x.SetState(It.IsAny<Domain.Models.BacklogItemDoneState>()));
    }
    
    [Test]
    public void SetTested_WhenInvoked_SetsStateToTested()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        var state = new Domain.Models.BacklogItemTodoState(context.Object);
        
        // Act
        state.SetTested();
        
        // Assert
        context.Verify(x => x.SetState(It.IsAny<Domain.Models.BacklogItemTestedState>()));
    }
}