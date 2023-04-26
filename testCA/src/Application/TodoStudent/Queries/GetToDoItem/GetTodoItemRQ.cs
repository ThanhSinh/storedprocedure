using AutoMapper;
using AutoMapper.QueryableExtensions;
using testCA.Application.Common.Interfaces;
using testCA.Application.Common.Mappings;
using testCA.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using testCA.Application.TodoItems.Queries.GetTodoItemsWithPagination;


namespace testCA.Application.TodoStudent.Queries.GetToDoItem;

public record GetTodoItemRQ : IRequest<List<TodoItemBriefDto>>
{
    public int studentID { get; init; }
   
}

public class GetTodoItemsHandler : IRequestHandler<GetTodoItemRQ, List<TodoItemBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodoItemsHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TodoItemBriefDto>> Handle(GetTodoItemRQ request, CancellationToken cancellationToken)
    {
        var students = await _context.Students.FromSqlRaw("EXEC GetAllTStudent").ToListAsync(cancellationToken);
        var todoItems = _mapper.Map<List<TodoItemBriefDto>>(students);

        return todoItems;
    }

}
