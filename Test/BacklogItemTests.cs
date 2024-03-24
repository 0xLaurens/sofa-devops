using Domain.Interfaces;
using Domain.Models;
using Domain.Models.UserRoles;

namespace Test;

public class BacklogItemTests
{
    // integration test: F3 Check if Activity can be added to BacklogItem
    [Test]
    public void Add_Activity()
    {
        Backlog backlog = new Backlog("Test Backlog");
        BacklogItem backlogItem = new BacklogItem("test user-story");
        backlog.AddBacklogItem(backlogItem);
        User user = new Developer("developer", "email@developer.nl");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
      
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));
        backlogItem.AddActivity(activity);
        
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityTodoState)));
        Assert.That(backlog.GetBacklogItems().Count, Is.GreaterThanOrEqualTo(1));
        Assert.That(backlogItem.getActivities().Count, Is.GreaterThanOrEqualTo(1));
    }
    
    // integration test: F6 Check state of BacklogItem
    [Test]
    public void Check_BacklogItem_State()
    {
        Backlog backlog = new Backlog("Test Backlog");
        BacklogItem backlogItem = new BacklogItem("test user-story");
        backlog.AddBacklogItem(backlogItem);
        User user = new Developer("developer", "email@developer.nl");
        User user2 = new Developer("lead-developer", "email@leaddeveloper.nl");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
       
        IActivityContext activity2 = new Activity("test activity 2", user2, backlogItem);
   
        IActivityContext activity3 = new Activity("test activity 3", user2, backlogItem);
       
        activity.SetState(new Domain.Activity.ActivityDoingState(activity));
        activity.GetState().SetReadyForTesting();
        activity2.SetState(new Domain.Activity.ActivityReadyForTestingState(activity2));
        activity2.GetState().SetTesting();
        activity3.SetState(new Domain.Activity.ActivityReadyForTestingState(activity3));
        activity3.GetState().SetTesting();
        backlogItem.AddActivity(activity);
        backlogItem.AddActivity(activity2);
        backlogItem.AddActivity(activity3);
        
        
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityReadyForTestingState)));
        Assert.That(activity2.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityTestingState)));
        Assert.That(activity3.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityTestingState)));
        Assert.That(backlog.GetBacklogItems().Count, Is.GreaterThanOrEqualTo(1));
        Assert.That(backlogItem.getActivities().Count, Is.GreaterThanOrEqualTo(1));
        Assert.That(backlogItem.GetState(), Is.EqualTo(Domain.Models.BacklogItemState.Ready));
    }
    
    // Integration test: F9 Check if Tester gets notification when all Activities are ready for testing
    [Test]
    public void Send_Notification_When_All_Ready_for_Testing()
    {
        Backlog backlog = new Backlog("Test Backlog");
        BacklogItem backlogItem = new BacklogItem("test user-story");
        backlog.AddBacklogItem(backlogItem);
        User user = new Developer("developer", "email@developer.nl");
        User user2 = new Developer("lead-developer", "email@leaddeveloper.nl");
        IActivityContext activity = new Activity("test activity", user2, backlogItem);
      
        IActivityContext activity2 = new Activity("test activity 2", user2, backlogItem);
      
        IActivityContext activity3 = new Activity("test activity 3", user2, backlogItem);

        backlogItem.AddActivity(activity);
        backlogItem.AddActivity(activity2);
        backlogItem.AddActivity(activity3);
        activity.Subscribe(new EmailNotificationSubscriber());
        activity2.Subscribe(new EmailNotificationSubscriber());
        activity3.Subscribe(new EmailNotificationSubscriber());
        
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            activity.SetState(new Domain.Activity.ActivityTodoState(activity));
            activity.GetState().SetDoing();
            activity2.SetState(new Domain.Activity.ActivityDoingState(activity2));
            activity2.GetState().SetReadyForTesting();
            activity3.SetState(new Domain.Activity.ActivityDoingState(activity3));
            activity3.GetState().SetReadyForTesting();
            activity.GetState().SetReadyForTesting();

            // Assert
            string expectedOutput = $"Sending email notification\r\nSending email notification\r\nSending email notification\r\nSending email notification\r\nSending email notification\r\nSending email notification\r\nSending email notification\r\nSending email notification\r\n";
                            
            Assert.AreEqual(expectedOutput, sw.ToString());
        }
        
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityReadyForTestingState)));
        Assert.That(activity2.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityReadyForTestingState)));
        Assert.That(activity3.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityReadyForTestingState)));
        Assert.That(backlog.GetBacklogItems().Count, Is.GreaterThanOrEqualTo(1));
        Assert.That(backlogItem.getActivities().Count, Is.GreaterThanOrEqualTo(1));
        Assert.That(backlogItem.GetState(), Is.EqualTo(Domain.Models.BacklogItemState.Ready));
    }
}