using Domain.Activity;
using Domain.Interfaces;

namespace Domain.Models;

public class Activity: IActivityContext, IPublisher
{
   private IActivityState _state;
   private List<ISubscriber> _subscribers = [];
   public void SetState(IActivityState state)
   {
      _state = state;
      this.Notify();
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