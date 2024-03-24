using Domain.Interfaces;
using Domain.Models;
using Domain.Models.SprintState;

namespace Test;

public class SprintTests
{
    // Integration test: F2 Check if user can create Sprint
    [Test]
    public void Add_Sprint()
    {
        ISprintContext sprint = new Sprint("sprint 1", new DateTime(2024, 03, 25), new DateTime(2024, 04, 08));
        
        sprint.SetState(new SprintProvisionedState(sprint));
        
        Assert.That(sprint.GetState().GetType(), Is.EqualTo(typeof(Domain.Models.SprintState.SprintProvisionedState)));
    }
    
    // Integration test: F4 Attach Backlog to Sprint
    [Test]
    public void Attach_Backlog()
    {
        ISprintContext sprint = new Sprint("sprint 1", new DateTime(2024, 03, 25), new DateTime(2024, 04, 08));

        sprint.SetState(new SprintProvisionedState(sprint));
        Backlog backlog = new Backlog("Test Backlog");
        BacklogItem backlogItem = new BacklogItem("test user-story");
        backlog.AddBacklogItem(backlogItem);
        sprint.SetBacklog(backlog);
        
        Assert.That(sprint.GetBacklog(), Is.EqualTo(backlog));
        Assert.That(backlog.GetBacklogItems().Count, Is.GreaterThanOrEqualTo(1));
        Assert.That(sprint.GetState().GetType(), Is.EqualTo(typeof(SprintProvisionedState)));

    }
    
    // Integration test: F8 Check if Start & End date of Sprint can be set and don't overlap
    [Test]
    public void SetStartDateandEndDate()
    {
        var project = new Project("test project");
        var sprint = new Sprint("sprint 1", new DateTime(2024, 03, 25), new DateTime(2024, 04, 08));
        var sprint2 = new Sprint("sprint 2", new DateTime(2024, 03, 28), new DateTime(2024, 04, 11));
        project.AddSprint(sprint);


        Assert.That(sprint.GetStartDate(), Is.EqualTo(new DateTime(2024, 03, 25)));
        Assert.That(sprint.GetEndDate(), Is.EqualTo(new DateTime(2024, 04, 08)));
        Assert.Throws<InvalidOperationException>(() => project.AddSprint(sprint2));
    }

}

