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
}