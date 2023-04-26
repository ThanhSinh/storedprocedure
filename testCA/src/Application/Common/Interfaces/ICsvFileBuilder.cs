using testCA.Application.TodoLists.Queries.ExportTodos;

namespace testCA.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
