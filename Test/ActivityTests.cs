using Domain.Interfaces;
using Domain.Models;
using Domain.Models.UserRoles;

namespace Test;

public class ActivityTests
{
    // integration test: F5 Check if User can be attached to Activity
    [Test]
    public void Attach_User_to_Backlog()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        

        Assert.That(activity.getUser().GetUsername(), Is.EqualTo("developer"));
    }
    
    // integration test: F7 Change state of Activity
    [Test]
    public void Change_Activity_State()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
       
        
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));
        activity.GetState().SetDoing();
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityDoingState)));
    }
    
    // integration test: F11 Check if user switches Activity
    [Test]
    public void Check_User_has_Multiple_Activities()
    {
        
        
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            
            User user = new Developer("developer", "email@developer.nl");
        
            BacklogItem backlogItem = new BacklogItem("Test backlog");
            IActivityContext activity = new Activity("test activity", user, backlogItem);
            backlogItem.AddActivity(activity);

            
            IActivityContext activity2 = new Activity("test activity2", user, backlogItem);
        
            backlogItem.AddActivity(activity2);
            activity.Subscribe(new EmailNotificationSubscriber());
            activity2.Subscribe(new EmailNotificationSubscriber());
      
            activity.SetState(new Domain.Activity.ActivityTodoState(activity));
            activity.GetState().SetDoing();
            activity2.SetState(new Domain.Activity.ActivityTodoState(activity2));
            activity2.GetState().SetDoing();

            // Assert
            string expectedOutput = $"Sending notification to scrum master\r\nSending email notification\r\nSending email notification\r\nSending email notification\r\nSending email notification\r\n";
                            
            Assert.AreEqual(expectedOutput, sw.ToString());
            Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityDoingState)));
            Assert.That(activity2.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityDoingState)));
        }
        
        
    }
   
}