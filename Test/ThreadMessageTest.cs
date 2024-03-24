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
}