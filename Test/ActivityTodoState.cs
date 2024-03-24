using Domain.Interfaces;
using Domain.Models;
using Domain.Models.UserRoles;

namespace Test;

public class ActivityTodoState
{
    [Test]
    public void Activity_SetDoing()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));
        activity.GetState().SetDoing();
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityDoingState)));
    }

    [Test]
    public void Activity_SetTodo()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        Activity activity = new Activity("test activity", user, backlogItem);
        
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));
        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTodo());
    }

    [Test]
    public void Activity_SetReadyForTesting()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));
        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetReadyForTesting());
    }

    [Test]
    public void Activity_SetTested()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));

        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTested());
    }

    [Test]
    public void Activity_SetTesting()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));
        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTesting());
    }

    [Test]
    public void Activity_SetDone()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test, activity", user, backlogItem);
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));

        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetDone());
    }

    [Test]
    public void ActivityDoing_NotifyEmail()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        

        activity.Subscribe(new EmailNotificationSubscriber());

        var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));

        // Assert
        const string expectedOutput = $"Sending email notification\r\n";

        Assert.That(sw.ToString(), Is.EqualTo(expectedOutput));
    }

    [Test]
    public void ActivityDoing_NotifyWhatsapp()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        

        activity.Subscribe(new WhatsappNotificationSubscriber());

        var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));

        // Assert
        const string expectedOutput = $"Sending whatsapp notification\r\n";

        Assert.That(sw.ToString(), Is.EqualTo(expectedOutput));
    }
}