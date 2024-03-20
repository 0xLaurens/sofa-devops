using Domain.Activity;
using Domain.Interfaces;

namespace Domain.Models;

public class BacklogItem
{
    // TODO: consider visitor pattern to check the activity their status to change the parents status. 
    private IVisitor _visitor;
    private List<Models.Activity> _activities;
    private List<Thread> _threads;

    
    //TODO: visitor pattern should combine the states of the different activities.
    public IActivityState GetState()
    {
        foreach (var activity in _activities)
        {
            _visitor.Visit(activity);     
        }

        return new ActivityDoingState();
    }
}