using Domain.Interfaces;
using Domain.Models;

namespace Test;

public class ActivityReadyForTestingState
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
        activity.SetState(new Domain.Activity.ActivityReadyForTestingState(activity));
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

        activity.SetState(new Domain.Activity.ActivityReadyForTestingState(activity));
        activity.GetState().SetTesting();

        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityTestingState)));
    }

    [Test]
    public void Activity_SetDone()
    {
        IActivityContext activity = new Activity();

        activity.SetState(new Domain.Activity.ActivityReadyForTestingState(activity));

        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetDone());
    }

    [Test]
    public void ActivityDoing_NotifyEmail()
    {
        IActivityContext activity = new Activity();


        activity.Subscribe(new EmailNotificationSubscriber());

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            activity.SetState(new Domain.Activity.ActivityReadyForTestingState(activity));

            // Assert
            const string expectedOutput = $"Sending email notification\r\n";

            Assert.That(sw.ToString(), Is.EqualTo(expectedOutput));
        }
    }

    [Test]
    public void ActivityDoing_NotifyWhatsapp()
    {
        IActivityContext activity = new Activity();

        activity.Subscribe(new WhatsappNotificationSubscriber());

        var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        activity.SetState(new Domain.Activity.ActivityReadyForTestingState(activity));

        // Assert
        const string expectedOutput = $"Sending whatsapp notification\r\n";

        Assert.That(sw.ToString(), Is.EqualTo(expectedOutput));
    }
}