using Domain.Activity;
using Domain.Interfaces;

namespace Domain.Models;

public class BacklogItem
{
    // TODO: consider visitor pattern to check the activity their status to change the parents status. 

    private List<Models.Activity> _activities;
    private List<Thread> _threads;

    public BacklogItem()
    {
        this._activities = new List<Activity>();
    }

    
    //TODO: visitor pattern should combine the states of the different activities.
    public BacklogItemState GetState()
    {
        
    

        // Dictionary to map IActivityState to BacklogItemState
        Dictionary<Type, BacklogItemState> stateMap = new Dictionary<Type, BacklogItemState>
        {
            { typeof(ActivityTodoState), BacklogItemState.Todo },
            { typeof(ActivityDoingState), BacklogItemState.Doing },
            { typeof(ActivityReadyForTestingState), BacklogItemState.Ready },
            { typeof(ActivityTestingState), BacklogItemState.Testing },
            { typeof(ActivityTestedState), BacklogItemState.Tested },
            { typeof(ActivityDoneState), BacklogItemState.Done }
        };
        
        
        
        foreach (BacklogItemState state in Enum.GetValues(typeof(BacklogItemState)))
        {
            if (_activities.Any(activity => stateMap[activity.GetState().GetType()] == state))
                return state;
        }

       

        // If no activity is found, return the default state (Done)
        return BacklogItemState.Done;
    }

    public List<Models.Activity> getActivities()
    {
        return _activities;
    }



}