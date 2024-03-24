using Domain.Interfaces;
using Domain.Models;
using Domain.Models.SprintState;


public class Sprint: ISprintContext
{
    private ISprintState _sprintState; 
    
    private Review _review;
    private string _name;
    private DateTime _startDate;
    private DateTime _endDate;
    private DateTime _created;
    private Backlog _sprintBacklog;
 

    public Sprint(string name, DateTime startDate, DateTime endDate)
    {
        _sprintState = new SprintProvisionedState(this);
        _name = name;
        _startDate = startDate;
        _endDate = endDate;
        _created = DateTime.Now;
        
        _review = new Review();
   
        
      
        
        





    }

    public void SetState(ISprintState state)
    {
        _sprintState = state;
    }

    public ISprintState GetState()
    {
        return _sprintState;
    }

    public void SetBacklog(Backlog backlog)
    {
        _sprintBacklog = backlog;
    }

    public Backlog GetBacklog()
    {
        return _sprintBacklog;
    }

    public DateTime GetStartDate()
    {
        return _startDate;
    }

    public DateTime GetEndDate()
    {
        return _endDate;
    }
}