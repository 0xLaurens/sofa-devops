using Domain.Activity;
using Domain.Interfaces;
using Domain.Models;

namespace Test;

public class BacklogItemState
{
    [Test]
    public void BacklogItem_GetState()
    {
        var item = new BacklogItem();
        
        var activity = new Activity();
        activity.SetState(new Domain.Activity.ActivityTodoState(activity));
        activity.GetState().SetDoing();
        
        var activity2 = new Activity();
        activity2.SetState(new Domain.Activity.ActivityDoingState(activity));
        activity2.GetState().SetReadyForTesting();
        
        var activity3 = new Activity();
        activity3.SetState(new Domain.Activity.ActivityDoingState(activity));
        activity3.GetState().SetReadyForTesting();
        
        var activity4 = new Activity();
        activity4.SetState(new Domain.Activity.ActivityTestedState(activity));
        activity4.GetState().SetReadyForTesting();
        
        item.AddActivity(activity);
        item.AddActivity(activity2);
        item.AddActivity(activity3);
        item.AddActivity(activity4);

        item.GetState();
        
        Assert.That(item.GetState(), Is.EqualTo(Domain.Models.BacklogItemState.Doing));
    }
}