using Domain.Activity;
using Domain.Interfaces;
using Domain.Models;

namespace Test;

public class BacklogItemStateTest
{
    [Test]
    public void BacklogItem_GetState()
    {
        BacklogItem item = new BacklogItem();
        
        Activity activity = new Activity();
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));
        activity.GetState().SetDoing();
        
        Activity activity2 = new Activity();
        activity2.SetState(new Domain.Activity.ActivityDoingState(activity));
        activity2.GetState().SetTesting();
        
        Activity activity3 = new Activity();
        activity3.SetState(new Domain.Activity.ActivityDoingState(activity));
        activity3.GetState().SetTesting();
        
        Activity activity4 = new Activity();
        activity4.SetState(new Domain.Activity.ActivityTestedState(activity));
        activity4.GetState().SetReadyForTesting();
        
        item.getActivities().Add(activity);
        item.getActivities().Add(activity2);
        item.getActivities().Add(activity3);
        item.getActivities().Add(activity4);

        item.GetState();
        
        Assert.That(item.GetState(), Is.EqualTo(BacklogItemState.Doing));
    }

    [Test]
    public void BacklogItem_GetState_Ready_Failed()
    {
        
    }
    
    
}