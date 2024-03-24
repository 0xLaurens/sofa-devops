using Domain.Models;
using Moq;

namespace Test;

public class BacklogTests
{
    // integration test: F1 Check if BacklogItem is added to Backlog
    [Test]
    public void Add_BacklogItem()
    {
        Backlog backlog = new Backlog("Domain.Test Backlog");
        BacklogItem backlogItem = new BacklogItem("test user-story");
        backlog.AddBacklogItem(backlogItem);
        
        Assert.That(backlog.GetBacklogItems().Count, Is.GreaterThanOrEqualTo(1));
    }
}