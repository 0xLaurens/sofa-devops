using Domain.Activity;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.UserRoles;

namespace Test;

public class BacklogItemState
{
    [Test]
    public void BacklogItem_GetState()
    {
        BacklogItem item = new BacklogItem("test user-story");
        User user = new Developer("developer", "email@developer.nl");
        User user2 = new Developer("lead-developer", "email@leaddeveloper.nl");
        BacklogItem backlogItem = new BacklogItem("Test backlog");
        Activity activity = new Activity("test activity", user, backlogItem);

        activity.SetState(new Domain.Activity.ActivityTodoState(activity));
        activity.GetState().SetDoing();
        
        Activity activity2 = new Activity("test activity 2", user, backlogItem);
    
        activity2.SetState(new Domain.Activity.ActivityDoingState(activity));
        activity2.GetState().SetReadyForTesting();
    
        Activity activity3 = new Activity("test activity 3", user, backlogItem);
        activity3.SetState(new Domain.Activity.ActivityDoingState(activity));
        activity3.GetState().SetReadyForTesting();
  
        Activity activity4 = new Activity("test activity 4", user, backlogItem);
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