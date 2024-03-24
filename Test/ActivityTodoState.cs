using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Notification;

namespace Test;

public class ActivityTodoState
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
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));
        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTodo());
    }

    [Test]
    public void Activity_SetReadyForTesting()
    {
        IActivityContext activity = new Activity();

        activity.SetState(new Domain.Activity.ActivityTodoState(activity));
        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetReadyForTesting());
    }

    [Test]
    public void Activity_SetTested()
    {
        IActivityContext activity = new Activity();

        activity.SetState(new Domain.Activity.ActivityTodoState(activity));

        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTested());
    }

    [Test]
    public void Activity_SetTesting()
    {
        IActivityContext activity = new Activity();

        activity.SetState(new Domain.Activity.ActivityTodoState(activity));
        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTesting());
    }

    [Test]
    public void Activity_SetDone()
    {
        IActivityContext activity = new Activity();

        activity.SetState(new Domain.Activity.ActivityTodoState(activity));

        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetDone());
    }

    [Test]
    public void ActivityDoing_NotifyEmail()
    {
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
        var activity = new Activity();
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