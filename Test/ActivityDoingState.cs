using Domain.Activity;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Notification;
using Moq;

namespace Test;

public class ActivityDoingState
{
    [Test]
    public void Activity_SetDoing()
    {
        IActivityContext activity = new Activity();

        activity.SetState(new Domain.Activity.ActivityTodoState(activity));
        activity.GetState().SetDoing();
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityDoingState)));
    }

    [Test]
    public void Activity_SetTodo()
    {
        Activity activity = new Activity();
        activity.SetState(new Domain.Activity.ActivityDoingState(activity));
        activity.GetState().SetTodo();
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityTodoState)));
    }

    [Test]
    public void Activity_SetReadyForTesting()
    {
        IActivityContext activity = new Activity();


        activity.SetState(new Domain.Activity.ActivityDoingState(activity));

        activity.GetState().SetReadyForTesting();
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityReadyForTestingState)));
    }

    [Test]
    public void Activity_SetTested()
    {
        IActivityContext activity = new Activity();

        activity.SetState(new Domain.Activity.ActivityDoingState(activity));

        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTested());
    }

    [Test]
    public void Activity_SetTesting()
    {
        IActivityContext activity = new Activity();

        activity.SetState(new Domain.Activity.ActivityDoingState(activity));

        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTesting());
    }

    [Test]
    public void Activity_SetDone()
    {
        IActivityContext activity = new Activity();

        activity.SetState(new Domain.Activity.ActivityDoingState(activity));

        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetDone());
    }

    [Test]
    public void ActivityDoing_NotifyEmail()
    {
        // Arrange
        var activity = new Activity();
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
        // Arrange
        var activity = new Activity();
        activity.Subscribe(new EmailNotificationSubscriber<IActivityContext>());
        
        var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        activity.SetState(new Domain.Activity.ActivityDoingState(activity));

        // Assert
        var expectedOutput = $"Sending email notification: {activity}";
        Assert.That(sw.ToString().Replace(System.Environment.NewLine, string.Empty), Is.EqualTo(expectedOutput));
    }
}