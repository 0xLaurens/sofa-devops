using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Notification;
using Domain.Models.UserRoles;

namespace Test;

public class ActivityTests
{
    // integration test: F5 Check if User can be attached to Activity
    [Test]
    public void Attach_User_to_Backlog()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Domain.Tests backlog");
        var activity = new Activity("test activity", user, backlogItem);


        Assert.That(activity.GetUser().GetUsername(), Is.EqualTo("developer"));
    }

    // integration test: F7 Change state of Activity
    [Test]
    public void Change_Activity_State()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Domain.Tests backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);


        activity.SetState(new Domain.Activity.ActivityTodoState(activity));
        activity.GetState().SetDoing();
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityDoingState)));
    }

    // integration test: F11 Check if user switches Activity
    [Test]
    public void Check_User_has_Multiple_Activities()
    {
        var sw = new StringWriter();
        Console.SetOut(sw);
    
        var user = new Developer("developer", "email@developer.nl");
        var backlogItem = new BacklogItem("Domain.Tests backlog");
        var activity = new Activity("test activity", user, backlogItem);
        backlogItem.AddActivity(activity);
    
        var activity2 = new Activity("test activity2", user, backlogItem);
    
        backlogItem.AddActivity(activity2);
        activity.Subscribe(new EmailNotificationSubscriber<IActivityContext>());
        activity2.Subscribe(new EmailNotificationSubscriber<IActivityContext>());
    
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));
        activity.GetState().SetDoing();
        activity2.SetState(new Domain.Activity.ActivityTodoState(activity2));
        activity2.GetState().SetDoing();
    
        // Assert
        var expectedOutput =
            $"Sending notification to scrum master Sending email notification: Activity in state: Todo Sending email notification: {activity} Sending email notification: Activity in state: Todo Sending email notification: {activity} ";
        
        Assert.Multiple(() =>
        {
            Assert.That(sw.ToString().Replace(Environment.NewLine, " "), Is.EqualTo(expectedOutput));
            Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityDoingState)));
             Assert.That(activity2.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityDoingState)));
         });
     }
}