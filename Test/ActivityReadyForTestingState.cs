using Domain.Interfaces;
using Domain.Models;
using Domain.Models.UserRoles;

namespace Test;

public class ActivityReadyForTestingState
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
        IActivityContext activity = new Activity("test activity", user, backlogItem);
      
        activity.SetState(new Domain.Activity.ActivityReadyForTestingState(activity));
        activity.GetState().SetTodo();
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityTodoState)));
    }

    [Test]
    public void Activity_SetReadyForTesting()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        activity.SetState(new Domain.Activity.ActivityDoingState(activity));
        activity.GetState().SetReadyForTesting();
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityReadyForTestingState)));
    }

    [Test]
    public void Activity_SetTested()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        
        activity.SetState(new Domain.Activity.ActivityDoingState(activity));

        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTested());
    }

    [Test]
    public void Activity_SetTesting()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        activity.SetState(new Domain.Activity.ActivityReadyForTestingState(activity));
        activity.GetState().SetTesting();

        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityTestingState)));
    }

    [Test]
    public void Activity_SetDone()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
  
        activity.SetState(new Domain.Activity.ActivityReadyForTestingState(activity));

        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetDone());
    }

    [Test]
    public void ActivityDoing_NotifyEmail()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
   

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
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);

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