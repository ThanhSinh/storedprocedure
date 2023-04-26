using System.Collections.Generic;
using testCA.Application.Common.Mappings;
using testCA.Domain.Entities;

namespace testCA.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public class TodoItemBriefDto : IMapFrom<Student>
{
    public int Id { get; set; }

    
    public int studentID { get; set; }
    public string name { get; set; }
    public string email { get; set; }

}
