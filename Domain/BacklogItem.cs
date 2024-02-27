namespace Domain;

public class BacklogItem
{
    // TODO: consider visitor pattern to check the activity their status to change the parents status. 
    private List<Activity> _activities;
    private List<Thread> _threads;
}