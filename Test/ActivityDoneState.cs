using Domain.Interfaces;
using Domain.Models;
using Domain.Models.UserRoles;

namespace Test;

public class ActivityDoneState
{
          [Test]
    public void Activity_SetDoing()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
 
        
        activity.SetState(new Domain.Activity.ActivityDoneState(activity));
        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetDoing());
    }
    
    [Test]
    public void Activity_SetTodo()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
       
        activity.SetState(new Domain.Activity.ActivityDoneState(activity));
        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTodo());
    }
    
    [Test]
    public void Activity_SetReadyForTesting()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
       
        activity.SetState(new Domain.Activity.ActivityDoneState(activity));
        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetReadyForTesting());
    }
    
    [Test]
    public void Activity_SetTested()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);

        activity.SetState(new Domain.Activity.ActivityDoneState(activity));
        
        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTested());
        
    }
    
    [Test]
    public void Activity_SetTesting()
    {

        
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        
        activity.SetState(new Domain.Activity.ActivityDoneState(activity));
        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTesting());
    }
    
    [Test]
    public void Activity_SetDone()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        
        activity.SetState(new Domain.Activity.ActivityTestedState(activity));
        activity.GetState().SetDone();
        Assert.That(activity.GetState().GetType(), Is.EqualTo(typeof(Domain.Activity.ActivityDoneState)));
        
       
        

    }
    
    [Test]
    public void ActivityDone_NotifyEmail()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
        

        activity.Subscribe(new EmailNotificationSubscriber());
        
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            activity.SetState(new Domain.Activity.ActivityDoneState(activity));

            // Assert
            string expectedOutput = $"Sending email notification\r\n";
                            
            Assert.AreEqual(expectedOutput, sw.ToString());
        }
        
    }
    
    [Test]
    public void ActivityDone_NotifyWhatsapp()
    {
        User user = new Developer("developer", "email@developer.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        IActivityContext activity = new Activity("test activity", user, backlogItem);
       

        activity.Subscribe(new WhatsappNotificationSubscriber());
        
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            activity.SetState(new Domain.Activity.ActivityDoneState(activity));

            // Assert
            string expectedOutput = $"Sending whatsapp notification\r\n";
                            
            Assert.AreEqual(expectedOutput, sw.ToString());
        }
        
    }
}