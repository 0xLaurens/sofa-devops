using Domain.Models;
using Domain.Models.UserRoles;

namespace Test;

[TestFixture]
public class BacklogItemTest
{
    //TC25: assign user to backlog item
    [Test]
    public void AssignUser_ToBacklogItem()
    {
        // Arrange
        var backlogItem = new BacklogItem();
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
        var backlogItem = new BacklogItem();
        var backlogItem2 = new BacklogItem();
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
}