using Domain.Activity;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Notification;
using Domain.Models.UserRoles;

namespace Test;

public class ActivityDoingState
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
        IActivityContext activity = new Activity("test activity", user, backlogItem);

        activity.SetState(new Domain.Activity.ActivityDoingState(activity));
        activity.GetState().SetTodo();
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityTodoState)));
    }

    [Test]
    public void Activity_SetReadyForTesting()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Domain.Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        activity.SetState(new Domain.Activity.ActivityDoingState(activity));

        activity.GetState().SetReadyForTesting();
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityReadyForTestingState)));
    }

    [Test]
    public void Activity_SetTested()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Domain.Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        activity.SetState(new Domain.Activity.ActivityDoingState(activity));

        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTested());
    }

    [Test]
    public void Activity_SetTesting()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Domain.Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        activity.SetState(new Domain.Activity.ActivityDoingState(activity));

        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTesting());
    }

    [Test]
    public void Activity_SetDone()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Domain.Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        activity.SetState(new Domain.Activity.ActivityDoingState(activity));

        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetDone());
    }

    [Test]
    public void ActivityDoing_NotifyEmail()
    {
        // Arrange

        var sw = new StringWriter();
        Console.SetOut(sw);
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Domain.Test backlog");
        var activity = new Activity("test activity", user, backlogItem);

        // Act
        activity.Subscribe(new EmailNotificationSubscriber<IActivityContext>());
        activity.SetState(new Domain.Activity.ActivityDoingState(activity));

        // Assert
        var expectedOutput = $"Sending email notification: {activity}";
        Assert.That(sw.ToString().Replace(System.Environment.NewLine, string.Empty), Is.EqualTo(expectedOutput));
    }

    [Test]
    public void ActivityDoing_NotifyWhatsapp()
    {
        // Arrange
        var user = new Developer("developer", "email@developer.nl");
        var backlogItem = new BacklogItem("Domain.Test backlog");
        var activity = new Activity("test activity", user, backlogItem);
        
        var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        activity.Subscribe(new EmailNotificationSubscriber<IActivityContext>());
        activity.SetState(new Domain.Activity.ActivityDoingState(activity));

        // Assert
        var expectedOutput = $"Sending email notification: {activity}";
        Assert.That(sw.ToString().Replace(System.Environment.NewLine, string.Empty), Is.EqualTo(expectedOutput));
    }
}