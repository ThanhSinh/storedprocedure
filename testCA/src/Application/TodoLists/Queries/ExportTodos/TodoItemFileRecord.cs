using testCA.Application.Common.Mappings;
using testCA.Domain.Entities;

namespace testCA.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
