using Domain.Interfaces;
using Domain.Models;

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
}