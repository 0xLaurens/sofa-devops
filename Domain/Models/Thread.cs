using Domain.Interfaces;
using Domain.Models.SprintState;

namespace Domain.Models;

public class Thread(ISprintContext sprint) 
{
    private readonly List<Message> _messages = [];
    private readonly ISet<User> _participants = new HashSet<User>();

    public void AddMessage(Message msg)
    {
        _participants.Add(msg.GetAuthor()); 
        
        if (sprint.GetState().GetType() == typeof(SprintFinishedState))
        {
            throw new InvalidOperationException("Cannot alter the thread of a finished sprint");
        }

        _messages.Add(msg);
        NotifyParticipants();
    }

    public void RemoveMessage(Message msg)
    {
        if (sprint.GetState().GetType() == typeof(SprintFinishedState))
        {
            throw new InvalidOperationException("Cannot alter the thread of a finished sprint");
        }

        _messages.Remove(msg);
    }

    private void NotifyParticipants()
    {
        foreach (var participant in _participants)
        {
            participant.SendNotification(_messages.Last());
        }
    }
}