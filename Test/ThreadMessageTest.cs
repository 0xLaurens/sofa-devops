using Domain.Models;
using Domain.Models.UserRoles;
using Thread = Domain.Models.Thread;

namespace Test;

public class ThreadMessageTest
{
    [Test]
    public void Thread_NotifyEmail()
    {
        Thread thread = new Thread();
        
        thread.Subscribe(new EmailNotificationSubscriber());
        
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            Message message = new Message(new Developer("developer", "email@developer.nl"), "test message",
                new DateTime(2024, 03, 23));
            thread.AddMessage(message);

            // Assert
            string expectedOutput = $"Sending email notification\r\n";
                            
            Assert.AreEqual(expectedOutput, sw.ToString());
        }

    }
    
    [Test]
    public void Thread_NotifyWhatsapp()
    {
        Thread thread = new Thread();
        
        thread.Subscribe(new WhatsappNotificationSubscriber());
        
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            Message message = new Message(new Developer("scrummaster", "email@scrummaster.nl"), "test message",
                new DateTime(2024, 03, 23));
            thread.AddMessage(message);

            // Assert
            string expectedOutput = $"Sending whatsapp notification\r\n";
                            
            Assert.AreEqual(expectedOutput, sw.ToString());
        }

    }
}