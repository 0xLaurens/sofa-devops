using Domain.Models.UserFactory;
using Domain.Models.UserRoles;

namespace Test;

[TestFixture]
public class UserFactory
{
    [Test]
    public void TestDeveloperUserCreator()
    {
        // arrange
        var creator = new DeveloperUserCreator();
        var user = creator.CreateUser("John Doe", "john@pro.gg");
        // act and assert
        Assert.Multiple(() =>
        {
            Assert.That(user.GetUsername(), Is.EqualTo("John Doe"));
            Assert.That(user.GetEmail(), Is.EqualTo("john@pro.gg"));
            Assert.That(user.GetType(), Is.EqualTo(typeof(Developer)));
        });
    }

    [Test]
    public void TestLeadDeveloperUserCreator()
    {
        // arrange
        var creator = new LeadDeveloperUserCreator();
        var user = creator.CreateUser("John Doe", "john@pro.gg");
        // act and assert
        Assert.Multiple(() =>
        {
            Assert.That(user.GetUsername(), Is.EqualTo("John Doe"));
            Assert.That(user.GetEmail(), Is.EqualTo("john@pro.gg"));
            Assert.That(user.GetType(), Is.EqualTo(typeof(LeadDeveloper)));
        });
    }

    [Test]
    public void TestProductOwnerUserCreator()
    {
        // arrange
        var creator = new ProductOwnerUserCreator();
        var user = creator.CreateUser("John Doe", "john@pro.gg");
        // act and assert
        Assert.Multiple(() =>
        {
            Assert.That(user.GetUsername(), Is.EqualTo("John Doe"));
            Assert.That(user.GetEmail(), Is.EqualTo("john@pro.gg"));
            Assert.That(user.GetType(), Is.EqualTo(typeof(ProductOwner)));
        });
    }

    [Test]
    public void TestScrumMasterUserCreator()
    {
        // arrange
        var creator = new ScrumMasterUserCreator();
        var user = creator.CreateUser("John Doe", "john@pro.gg");
        // act and assert
        Assert.Multiple(() =>
        {
            Assert.That(user.GetUsername(), Is.EqualTo("John Doe"));
            Assert.That(user.GetEmail(), Is.EqualTo("john@pro.gg"));
            Assert.That(user.GetType(), Is.EqualTo(typeof(ScrumMaster)));
        });
    }
}