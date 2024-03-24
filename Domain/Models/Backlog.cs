namespace Domain.Models;

public class Backlog
{
    private List<BacklogItem> _backlogItems;
    private string _name;

    public Backlog(string name)
    {
        _backlogItems = new List<BacklogItem>();
        _name = name;
    }

    public void AddBacklogItem(BacklogItem item)
    {
        _backlogItems.Add(item);
    }
    
    public List<BacklogItem> GetBacklogItems()
    {
        return _backlogItems;
    }

    public void RemoveBacklogItem(BacklogItem item)
    {
        throw new NotImplementedException();
    }

    public void UpdateBacklogItem(BacklogItem item)
    {
        throw new NotImplementedException();
    }
}