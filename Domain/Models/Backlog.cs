namespace Domain.Models;

public class Backlog
{
    private List<BacklogItem> _backlogItems;

    public void AddBacklogItem(BacklogItem item)
    {
        _backlogItems.Add(item);
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