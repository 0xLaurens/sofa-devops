using Domain.Interfaces;
using Domain.Models;
using Domain.Models.UserRoles;
using Moq;

namespace Test;

public class ReportExportTests
{
    [Test]
    public void Export_HeaderReport_PDF()
    {
        var exportStrategy = new Mock<PdfExportStrategy>();
        List<User> users = new List<User>();
        User user1 = new ScrumMaster("scrummaster", "email@scrummaster.nl");
        User user2 = new Developer("developer", "email@Developer.nl");
        User user3 = new LeadDeveloper("leaddeveloper", "email@leaddeveloper.nl");
        User user4 = new ProductOwner("productowner", "email@productowner.nl");
        users.Add(user1);
        users.Add(user2);
        users.Add(user3);
        users.Add(user4);
        Report report = new Header(users, exportStrategy.Object, new BurndownChart());
        
        
        
        
        
        Assert.That(() => report.Export(), Throws.Nothing);
    }
    
    [Test]
    public void Export_HeaderReport_PNG()
    {
        var exportStrategy = new Mock<PngExportStrategy>();
        List<User> users = new List<User>();
        User user1 = new ScrumMaster("scrummaster", "email@scrummaster.nl");
        User user2 = new Developer("developer", "email@Developer.nl");
        User user3 = new LeadDeveloper("leaddeveloper", "email@leaddeveloper.nl");
        User user4 = new ProductOwner("productowner", "email@productowner.nl");
        users.Add(user1);
        users.Add(user2);
        users.Add(user3);
        users.Add(user4);
        Report report = new Header(users, exportStrategy.Object, new BurndownChart());
        
        
        
        
        
        Assert.That(() => report.Export(), Throws.Nothing);
    }
    
    [Test]
    public void Export_FooterReport_PNG()
    {
        var exportStrategy = new Mock<PngExportStrategy>();
        List<User> users = new List<User>();
        User user1 = new ScrumMaster("scrummaster", "email@scrummaster.nl");
        User user2 = new Developer("developer", "email@Developer.nl");
        User user3 = new LeadDeveloper("leaddeveloper", "email@leaddeveloper.nl");
        User user4 = new ProductOwner("productowner", "email@productowner.nl");
        users.Add(user1);
        users.Add(user2);
        users.Add(user3);
        users.Add(user4);
        Report report = new Footer(users, exportStrategy.Object, new BurndownChart());
        
        
        
        
        
        Assert.That(() => report.Export(), Throws.Nothing);
        //exportStrategy.Verify(x => x.ExportReport(), Times.Once);
        
    }
    
    [Test]
    public void Export_FooterReport_PDF()
    {
        var exportStrategy = new Mock<PdfExportStrategy>();
        List<User> users = new List<User>();
        User user1 = new ScrumMaster("scrummaster", "email@scrummaster.nl");
        User user2 = new Developer("developer", "email@Developer.nl");
        User user3 = new LeadDeveloper("leaddeveloper", "email@leaddeveloper.nl");
        User user4 = new ProductOwner("productowner", "email@productowner.nl");
        users.Add(user1);
        users.Add(user2);
        users.Add(user3);
        users.Add(user4);
        Report report = new Footer(users, exportStrategy.Object, new BurndownChart());
        
        
        
        
        
        Assert.That(() => report.Export(), Throws.Nothing);
        //exportStrategy.Verify(x => x.ExportReport(), Times.Once);
        
    }
}