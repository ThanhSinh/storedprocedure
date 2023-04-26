namespace testCA.Domain.Events;

public class TodoItemCreatedEvent : BaseEvent
{
 

    public TodoItemCreatedEvent(TodoItem item)
    {
        Item1 = item;
    }
    public TodoItemCreatedEvent(Student item)
    {
        Item = item;
    }



    public TodoItem Item1 { get; }
    public Student Item { get; }

}
