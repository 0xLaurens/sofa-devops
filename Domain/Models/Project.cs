namespace Domain.Models;

public class Project
{
    private string name;
    private List<Sprint> _sprints;

    public Project(string name)
    {
        _sprints = new List<Sprint>();
    }

    public void AddSprint(Sprint sprint)
    {
        
        
        if (_sprints.Any(s => s.GetEndDate() < sprint.GetStartDate()) || _sprints.Count == 0)
        {
                
            _sprints.Add(sprint);

        }
        else
        {
         
            throw new InvalidOperationException("dates overlap");
        }
    }
}