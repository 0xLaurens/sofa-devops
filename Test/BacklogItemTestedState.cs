using Domain.Interfaces;
using Domain.Models.UserRoles;
using Moq;

namespace Test;

// TC12: Lead developer is the only one who can approve the tested phase.
// TC13: A different user role tries to approve the tested phase. 
[TestFixture]
public class BacklogItemTestedState
{
    [Test]
    public void SetTodo_NotLeadDeveloper_ThrowsException()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        context.Setup(x => x.GetApprover()).Returns(new Developer("John", "john@gmail.com"));
        var state = new Domain.Models.BacklogItemTestedState(context.Object);

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => state.SetTodo());

        // Assert
        Assert.That(ex.Message, Is.EqualTo("Only Lead Developer can approve the tested phase."));
    }

    [Test]
    public void SetTodo_LeadDeveloper_SetsStateToTodo()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        context.Setup(x => x.GetApprover()).Returns(new LeadDeveloper("John", "john@gmail.com"));
        var state = new Domain.Models.BacklogItemTestedState(context.Object);

        // Act
        state.SetTodo();

        // Assert
        context.Verify(x => x.SetState(It.IsAny<Domain.Models.BacklogItemTodoState>()), Times.Once);
    }

    [Test]
    public void SetDoing_NotLeadDeveloper_ThrowsException()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        context.Setup(x => x.GetApprover()).Returns(new Developer("John", "john@gmail.com"));
        var state = new Domain.Models.BacklogItemTestedState(context.Object);

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => state.SetTodo());

        // Assert
        Assert.That(ex.Message, Is.EqualTo("Only Lead Developer can approve the tested phase."));
    }

    [Test]
    public void SetDoing_LeadDeveloper_SetsStateToDoing()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        context.Setup(x => x.GetApprover()).Returns(new LeadDeveloper("John", "john@gmail.com"));
        var state = new Domain.Models.BacklogItemTestedState(context.Object);

        // Act
        state.SetDoing();

        // Assert
        context.Verify(x => x.SetState(It.IsAny<Domain.Models.BacklogItemDoingState>()), Times.Once);
    }

    [Test]
    public void SetReadyForTesting_NotLeadDeveloper_ThrowsException()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        context.Setup(x => x.GetApprover()).Returns(new Developer("John", "john@gmail.com"));
        var state = new Domain.Models.BacklogItemTestedState(context.Object);

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => state.SetReadyForTesting());

        // Assert
        Assert.That(ex.Message, Is.EqualTo("Only Lead Developer can approve the tested phase."));
    }

    [Test]
    public void SetReadyForTesting_LeadDeveloper_SetsStateToReadyForTesting()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        context.Setup(x => x.GetApprover()).Returns(new LeadDeveloper("John", "john@gmail.com"));
        var state = new Domain.Models.BacklogItemTestedState(context.Object);

        // Act
        state.SetReadyForTesting();

        // Assert
        context.Verify(x => x.SetState(It.IsAny<Domain.Models.BacklogItemReadyForTestingState>()), Times.Once);
    }

    [Test]
    public void SetTesting_NotLeadDeveloper_ThrowsException()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        context.Setup(x => x.GetApprover()).Returns(new Developer("John", "john@gmai.com"));
        var state = new Domain.Models.BacklogItemTestedState(context.Object);
        
        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => state.SetTesting());
        
        // Assert
        Assert.That(ex.Message, Is.EqualTo("Only Lead Developer can approve the tested phase."));
    }

    [Test]
    public void SetTesting_LeadDeveloper_SetsStateToTesting()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        context.Setup(x => x.GetApprover()).Returns(new LeadDeveloper("John", "john@gmail.com"));
        var state = new Domain.Models.BacklogItemTestedState(context.Object);

        // Act
        state.SetTesting();

        // Assert
        context.Verify(x => x.SetState(It.IsAny<Domain.Models.BacklogItemTestingState>()), Times.Once);
    }

    [Test]
    public void SetTested_ThrowsException()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        var state = new Domain.Models.BacklogItemTestedState(context.Object);

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => state.SetTested());

        // Assert
        Assert.That(ex.Message, Is.EqualTo("Item is already in Tested state"));
    }

    [Test]
    public void SetDone_NotLeadDeveloper_ThrowsException()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        context.Setup(x => x.GetApprover()).Returns(new Developer("John", "john@gmail.com"));
        var state = new Domain.Models.BacklogItemTestedState(context.Object);

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => state.SetDone());

        // Assert
        Assert.That(ex.Message, Is.EqualTo("Only Lead Developer can approve the tested phase."));
    }

    [Test]
    public void SetDone_LeadDeveloper_SetsStateToDone()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        context.Setup(x => x.GetApprover()).Returns(new LeadDeveloper("John", "john@gmail.com"));
        var state = new Domain.Models.BacklogItemTestedState(context.Object);

        // Act
        state.SetDone();

        // Assert
        context.Verify(x => x.SetState(It.IsAny<Domain.Models.BacklogItemDoneState>()), Times.Once);
    }

    [Test]
    public void LeadDeveloperGuard_LeadDeveloper_DoesNotThrowException()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        context.Setup(x => x.GetApprover()).Returns(new LeadDeveloper("John", "john@gmail.com"));
        var state = new Domain.Models.BacklogItemTestedState(context.Object);

        // Act
        state.LeadDeveloperGuard();

        // Assert
        Assert.Pass();
    }

    [Test]
    public void LeadDeveloperGuard_NotLeadDeveloper_ThrowsException()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        context.Setup(x => x.GetApprover()).Returns(new Developer("John", "john@gmail.com"));
        var state = new Domain.Models.BacklogItemTestedState(context.Object);

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => state.LeadDeveloperGuard());

        // Assert
        Assert.That(ex.Message, Is.EqualTo("Only Lead Developer can approve the tested phase."));
    }
   
    [Test]
    public void LeadDeveloperGuard_NoApprover_ThrowsException()
    {
        // Arrange
        var context = new Mock<IBacklogItemContext>();
        context.Setup(x => x.GetApprover()).Returns(() => null);
        var state = new Domain.Models.BacklogItemTestedState(context.Object);

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => state.LeadDeveloperGuard());

        // Assert
        Assert.That(ex.Message, Is.EqualTo("No approver set for this item."));
    }
}