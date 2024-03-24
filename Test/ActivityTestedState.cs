using Domain.Activity;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Notification;

namespace Test;

public class ActivityTestedState
{
    [Test]
    public void Activity_SetDoing()
    {
        IActivityContext activity = new Activity();

        activity.SetState(new Domain.Activity.ActivityTestedState(activity));
        activity.GetState().SetDoing();
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityDoingState)));
    }

    [Test]
    public void Activity_SetTodo()
    {
        IActivityContext activity = new Activity();

        activity.SetState(new Domain.Activity.ActivityTestedState(activity));
        activity.GetState().SetTodo();
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityTodoState)));
    }

    [Test]
    public void Activity_SetReadyForTesting()
    {
        IActivityContext activity = new Activity();

        activity.SetState(new Domain.Activity.ActivityTestedState(activity));
        activity.GetState().SetReadyForTesting();
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityReadyForTestingState)));
    }

    [Test]
    public void Activity_SetTested()
    {
        IActivityContext activity = new Activity();

        activity.SetState(new Domain.Activity.ActivityTestingState(activity));
        activity.GetState().SetTested();
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityTestedState)));
    }

    [Test]
    public void Activity_SetTesting()
    {
        IActivityContext activity = new Activity();

        activity.SetState(new Domain.Activity.ActivityTestedState(activity));
        activity.GetState().SetTesting();
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityTestingState)));
    }

    [Test]
    public void Activity_SetDone()
    {
        IActivityContext activity = new Activity();

        activity.SetState(new Domain.Activity.ActivityTestedState(activity));
        activity.GetState().SetDone();
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityDoneState)));
    }

    [Test]
    public void ActivityDoing_NotifyEmail()
    {
        var activity = new Activity();
        activity.Subscribe(new EmailNotificationSubscriber<IActivityContext>());
        
        var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        activity.SetState(new Domain.Activity.ActivityTestedState(activity));

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
        activity.SetState(new Domain.Activity.ActivityTestedState(activity));

        // Assert
        var expectedOutput = $"Sending whatsapp notification: {activity}";
        Assert.That(sw.ToString().Replace(System.Environment.NewLine, string.Empty), Is.EqualTo(expectedOutput));

    }
}