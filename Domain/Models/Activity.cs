using Domain.Interfaces;

namespace Domain.Models;

public class Activity: IActivityContext
{
   private IActivityState _state;
   public void SetState(IActivityState state)
   {
      _state = state;
   }

   public IActivityState GetState()
   {
      return _state;
   }
}