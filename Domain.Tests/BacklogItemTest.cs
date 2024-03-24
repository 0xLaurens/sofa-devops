using Domain.Models;
using Domain.Models.UserRoles;
using Thread = Domain.Models.Thread;

namespace Test;

[TestFixture]
public class BacklogItemTest
{
    //TC25: assign user to backlog item
    [Test]
    public void AssignUser_ToBacklogItem()
    {
        // Arrange
        var backlogItem = new BacklogItem("Domain.Tests backlog");
        var user = new Developer("John", "John@gmail.com");

        // Act
        backlogItem.AssignUser(user);

        // Assert
        Assert.That(backlogItem.GetAssignedUser(), Is.EqualTo(user));
    }

    //TC26: assign already assigned user to backlog item 
    [Test]
    public void AssignUser_ToBacklogItem_ThrowsException()
    {
        // Arrange
        var backlogItem = new BacklogItem("Domain.Tests backlog");
        var backlogItem2 = new BacklogItem("Domain.Tests backlog2");
        var user = new Developer("John", "John@gmail.com");

        // Act
        backlogItem.AssignUser(user);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(backlogItem.GetAssignedUser(), Is.EqualTo(user));
            Assert.That(() => backlogItem2.AssignUser(user), Throws.InvalidOperationException);
        });
    }

    [Test]
    public void AddThread_ToBacklogItem()
    {
        // Arrange
        var backlogItem = new BacklogItem("Domain.Tests backlog");
        var sprint = new Sprint("Domain.Tests sprint", DateTime.Now, DateTime.Now.AddDays(7));
        var thread = new Thread(sprint);

        // Act
        backlogItem.AddThread(thread);

        // Assert
        Assert.That(backlogItem.GetThreads(), Contains.Item(thread));
    }
    
    [Test]
    public void RemoveThread_FromBacklogItem()
    {
        // Arrange
        var backlogItem = new BacklogItem("Domain.Tests backlog");
        var sprint = new Sprint("Domain.Tests sprint", DateTime.Now, DateTime.Now.AddDays(7));
        var thread = new Thread(sprint);
        backlogItem.AddThread(thread);

        // Act
        backlogItem.RemoveThread(thread);

        // Assert
        Assert.That(backlogItem.GetThreads(), Does.Not.Contain(thread));
    }
    
    [Test]
    public void AddActivity_ToBacklogItem()
    {
        // Arrange
        var backlogItem = new BacklogItem("Domain.Tests backlog");
        var worker = new Developer("John", "john@gmail.com");
        var activity = new Activity("hello", worker, backlogItem);

        // Act
        backlogItem.AddActivity(activity);

        // Assert
        Assert.That(backlogItem.GetActivities(), Contains.Item(activity));
    }

    [Test]
    public void RemoveActivity_FromBacklogItem()
    {
        // Arrange
        var backlogItem = new BacklogItem("Domain.Tests backlog");
        var worker = new Developer("John", "john@gmail.com");
        var activity = new Activity("hello", worker, backlogItem);
        backlogItem.AddActivity(activity);
        
        // Act
        backlogItem.RemoveActivity(activity);
        
        // Assert
        Assert.That(backlogItem.GetActivities(), Does.Not.Contain(activity));
    }
}