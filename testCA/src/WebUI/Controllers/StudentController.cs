using MediatR;
using Microsoft.AspNetCore.Mvc;
using testCA.Application.TodoItems.Commands.CreateTodoItem;

using testCA.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using testCA.Application.TodoLists.Commands.DeleteTodoList;
using testCA.Application.TodoLists.Commands.UpdateTodoList;
using testCA.Application.TodoLists.Queries.GetTodos;
using testCA.Application.TodoStudent.Commands.AddItem;
using testCA.Application.TodoStudent.Commands.DeleteItem;
using testCA.Application.TodoStudent.Commands.UpDatteItem;
using testCA.Application.TodoStudent.Queries.GetToDoItem;
using testCA.WebUI.Controllers;

namespace WebUI.Controllers;
public class StudentController : ApiControllerBase
{
   /* [HttpGet]
    public async Task<ActionResult<TodosVm>> Get()
    {
        return await Mediator.Send(new GetTodosQuery());
    }*/
    [HttpGet]
    public async Task<ActionResult<List<TodoItemBriefDto>>> GetTodoItem()
    {
        return await Mediator.Send(new GetTodoItemRQ());
    }
    [HttpPost]
    public async Task<ActionResult<int>> Create(AddItem command)
    {
        return await Mediator.Send(command);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateItem command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteItem(id));

        return NoContent();
    }
}
