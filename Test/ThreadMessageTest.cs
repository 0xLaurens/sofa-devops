using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Notification;
using Domain.Models.UserRoles;
using Moq;
using Thread = Domain.Models.Thread;

namespace Test;

public class ThreadMessageTest
{
    // TC14: user selected notification method
    [Test]
    public void Thread_UserSelectsNotificationType_ReceivesEmailNotification()
    {
        // Arrange
        var ctx = new Mock<ISprintContext>();
        ctx.Setup(x => x.GetState()).Returns(new Domain.Models.SprintState.SprintActiveState(ctx.Object));

        var thread = new Thread(ctx.Object);
        var user = new Developer("Henricus", "Henricus@dev.com");
        var msg = new Message(user, "Hello", new DateTime(2024, 03, 23));

        var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        user.SetMsgNotifier(new EmailNotificationSubscriber<Message>());
        thread.AddMessage(msg);

        // Assert
        var expectedOutput = $"Sending email notification: {msg}";
        Assert.That(sw.ToString().Replace(System.Environment.NewLine, string.Empty), Is.EqualTo(expectedOutput));
    }

    // TC14: user selected notification method
    [Test]
    public void Thread_UserSelectsNotificationType_ReceivesWhatsappNotification()
    {
        // Arrange
        var ctx = new Mock<ISprintContext>();
        ctx.Setup(x => x.GetState()).Returns(new Domain.Models.SprintState.SprintActiveState(ctx.Object));

        var thread = new Thread(ctx.Object);
        var user = new Developer("Henricus", "Henricus@dev.com");
        var msg = new Message(user, "Hello", new DateTime(2024, 03, 23));

        var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        user.SetMsgNotifier(new WhatsappNotificationSubscriber<Message>());
        thread.AddMessage(msg);

        // Assert
        var expectedOutput = $"Sending whatsapp notification: {msg}";
        Assert.That(sw.ToString().Replace(System.Environment.NewLine, string.Empty), Is.EqualTo(expectedOutput));
    }

    // TC21: comment on a active thread
    [Test]
    public void Thread_ActiveSprint_AddCommentToActiveThread()
    {
        // Arrange
        var ctx = new Mock<ISprintContext>();
        ctx.Setup(x => x.GetState()).Returns(new Domain.Models.SprintState.SprintActiveState(ctx.Object));

        var thread = new Thread(ctx.Object);
        var user = new Developer("Henricus", "hericus@dev.com");
        var msg = new Message(user, "Hello", new DateTime(2024, 03, 23));

        var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        Assert.DoesNotThrow(() => thread.AddMessage(msg));
    }

    // TC22: comment on a closed finished sprint thread
    [Test]
    public void Thread_FinishedSprint_InvalidOperationException()
    {
        // Arrange
        var ctx = new Mock<ISprintContext>();
        ctx.Setup(x => x.GetState()).Returns(new Domain.Models.SprintState.SprintFinishedState(ctx.Object));

        var thread = new Thread(ctx.Object);
        var user = new Developer("Henricus", "hericus@dev.com");
        var msg = new Message(user, "Hello", new DateTime(2024, 03, 23));

        var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        var exception = Assert.Throws<InvalidOperationException>(() => thread.AddMessage(msg));
        
        // Assert
        Assert.That(exception?.Message, Is.EqualTo("Cannot alter the thread of a finished sprint"));
    }
    
    // TC23: notification to participants
    [Test]
    public void Thread_AddMessage_NotifyParticipants()
    {
        // Arrange
        var ctx = new Mock<ISprintContext>();
        ctx.Setup(x => x.GetState()).Returns(new Domain.Models.SprintState.SprintActiveState(ctx.Object));

        var thread = new Thread(ctx.Object);
        var user = new Developer("Henricus", "dev@henricus.com");
        user.SetMsgNotifier(new EmailNotificationSubscriber<Message>());
        var msg = new Message(user, "Hello", new DateTime(2024, 03, 23));

        var sw = new StringWriter();
        Console.SetOut(sw);
        
        // Act
        thread.AddMessage(msg);
        
        // Assert
        var expectedOutput = $"Sending email notification: {msg}";
        Assert.That(sw.ToString().Replace(System.Environment.NewLine, string.Empty), Is.EqualTo(expectedOutput));
    }
}