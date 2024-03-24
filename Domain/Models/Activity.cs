using Domain.Interfaces;

namespace Domain.Models;

public class Activity: IActivityContext, IPublisher
{
   private IActivityState _state;
   private string _description;
   private User _worker;
   private List<ISubscriber> _subscribers = new List<ISubscriber>();
   private BacklogItem _backlogItem;

   public Activity(string description, User worker, BacklogItem backlogItem)
   {
      _description = description;
      _backlogItem = backlogItem;
     
      
      
    
      
      // Check if worker's username already exists in _backlogItem.getActivities list
      if (_backlogItem.getActivities().Any(activity => activity.getUser().GetUsername() == worker.GetUsername()))
      {
         Console.WriteLine("Sending notification to scrum master");
        this.Notify();
       
      }
      
     
      _worker = worker;
      
      
     
      
      
      
    
      
      
   }
   public void SetState(IActivityState state)
   {
      _state = state;
      this.Notify();
   
      if (_backlogItem.getActivities()
          .All(x => x.GetState().GetType() == typeof(Domain.Activity.ActivityReadyForTestingState)))
      {
         this.Notify();
      }
      
     /* int count = _backlogItem.getActivities().Where(x => getUser().GetUsername().Contains(x.getUser().GetUsername())).Count();
      Console.WriteLine(count);
      if (count > 1)
      {
         this.Notify();
      }*/

         
   }


   public BacklogItem GetBacklogItem()
   {
      return _backlogItem;
   }

   

   public User getUser()
   {
      return _worker;
   }

   public IActivityState GetState()
   {
      return _state;
   }

   public void Subscribe(ISubscriber listener)
   {
      _subscribers.Add(listener);
   }

   public void Unsubscribe(ISubscriber listener)
   {
      _subscribers.Remove(listener);
   }

   public void Notify()
   {
      foreach (var subscriber in _subscribers)
      {
         subscriber.Update();
      }
   }
}