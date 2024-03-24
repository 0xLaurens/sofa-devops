using Domain.Interfaces;
using Domain.Models;

namespace Test;

public class ActivityDoneState
{
          [Test]
    public void Activity_SetDoing()
    {
        IActivityContext activity = new Activity();
        
        activity.SetState(new Domain.Activity.ActivityDoneState(activity));
        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetDoing());
    }
    
    [Test]
    public void Activity_SetTodo()
    {
        IActivityContext activity = new Activity();
        
        activity.SetState(new Domain.Activity.ActivityDoneState(activity));
        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTodo());
    }
    
    [Test]
    public void Activity_SetReadyForTesting()
    {
        IActivityContext activity = new Activity();
        
        activity.SetState(new Domain.Activity.ActivityDoneState(activity));
        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetReadyForTesting());
    }
    
    [Test]
    public void Activity_SetTested()
    {
        IActivityContext activity = new Activity();
        
        activity.SetState(new Domain.Activity.ActivityDoneState(activity));
        
        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTested());
        
    }
    
    [Test]
    public void Activity_SetTesting()
    {

        
        IActivityContext activity = new Activity();
        
        activity.SetState(new Domain.Activity.ActivityDoneState(activity));
        Assert.Throws<InvalidOperationException>(() => activity.GetState().SetTesting());
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
    public void ActivityDone_NotifyEmail()
    {
        IActivityContext activity = new Activity();


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
        IActivityContext activity = new Activity();


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