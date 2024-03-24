using Domain.Models;
using Domain.Models.Notification;
using Domain.Models.UserRoles;
using Thread = Domain.Models.Thread;

namespace Test;

public class ThreadMessageTest
{
    [Test]
    public void Thread_NotifyEmail()
    {
        var thread = new Thread();

        thread.Subscribe(new EmailNotificationSubscriber());

        var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        var message = new Message(new Developer("developer", "email@developer.nl"), "test message",
            new DateTime(2024, 03, 23));
        thread.AddMessage(message);

        // Assert
        const string expectedOutput = $"Sending email notification";

        Assert.That(sw.ToString().Replace(System.Environment.NewLine, string.Empty), Is.EqualTo(expectedOutput));
    }

    [Test]
    public void Thread_NotifyWhatsapp()
    {
        var thread = new Thread();

        thread.Subscribe(new WhatsappNotificationSubscriber());
        var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        var message = new Message(new ScrumMaster("scrummaster", "email@scrummaster.nl"), "test message",
            new DateTime(2024, 03, 23));
        thread.AddMessage(message);

        // Assert
        const string expectedOutput = $"Sending whatsapp notification";

        Assert.That(sw.ToString().Replace(System.Environment.NewLine, string.Empty), Is.EqualTo(expectedOutput));
    }
}