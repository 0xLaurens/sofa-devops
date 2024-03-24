using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Notification;
using Domain.Models.UserRoles;

namespace Test;

public class ActivityTodoState
{
    [Test]
    public void Activity_SetDoing()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Domain.Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));
        activity.GetState().SetDoing();
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityDoingState)));
    }

    [Test]
    public void Activity_SetTodo()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Domain.Test backlog");
        Activity activity = new Activity("test activity", user, backlogItem);
        
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));
        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTodo());
    }

    [Test]
    public void Activity_SetReadyForTesting()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Domain.Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));
        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetReadyForTesting());
    }

    [Test]
    public void Activity_SetTested()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Domain.Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));

        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTested());
    }

    [Test]
    public void Activity_SetTesting()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Domain.Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));
        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTesting());
    }

    [Test]
    public void Activity_SetDone()
    {
        var user = new Developer("developer", "email@developer.nl");
        var backlogItem = new BacklogItem("Domain.Test backlog");
        var activity = new Activity("test, activity", user, backlogItem);
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));

        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetDone());
    }

    [Test]
    public void ActivityDoing_NotifyEmail()
    {
        var user = new Developer("developer", "email@developer.nl");
        var backlogItem = new BacklogItem("Domain.Test backlog");
        var activity = new Activity("test activity", user, backlogItem);
        activity.Subscribe(new EmailNotificationSubscriber<IActivityContext>());

        var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        activity.SetState(new Domain.Activity.ActivityDoingState(activity));

        // Assert
        var expectedOutput = $"Sending email notification: {activity}";
        Assert.That(sw.ToString().Replace(System.Environment.NewLine, string.Empty), Is.EqualTo(expectedOutput));
    }

    [Test]
    public void ActivityDoing_NotifyWhatsapp()
    {
        var user = new Developer("developer", "email@developer.nl");
        var backlogItem = new BacklogItem("Domain.Test backlog");
        var activity = new Activity("test activity", user, backlogItem);
        
        activity.Subscribe(new WhatsappNotificationSubscriber<IActivityContext>());

        var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        activity.SetState(new Domain.Activity.ActivityDoingState(activity));

        // Assert
        var expectedOutput = $"Sending whatsapp notification: {activity}";

        Assert.That(sw.ToString().Replace(System.Environment.NewLine, string.Empty), Is.EqualTo(expectedOutput));
    }
}