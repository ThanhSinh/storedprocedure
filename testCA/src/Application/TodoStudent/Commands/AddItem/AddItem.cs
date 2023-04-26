using testCA.Application.Common.Interfaces;
using testCA.Domain.Entities;
using testCA.Domain.Events;
using MediatR;
using System.Data;
using Microsoft.Data.SqlClient;

namespace testCA.Application.TodoStudent.Commands.AddItem;

public record AddItem : IRequest<int>
{
    public int studentID { get; init; }

    public string name { get; init; }
    public string email { get; init; }
    
}

public class AddItemHandler : IRequestHandler<AddItem, int>
{
    private readonly IApplicationDbContext _context;

    public AddItemHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /*public async Task<int> Handle(AddItem request, CancellationToken cancellationToken)
    {
        var entity = new Student
        {
            studentID = request.studentID,
            name = request.name,
            email = request.email


        };

        //entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

        _context.Students.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }*/
    public async Task<int> Handle(AddItem request, CancellationToken cancellationToken)
    {
        var parameters = new List<SqlParameter>
        {
            new SqlParameter("@studentID", request.studentID),
            new SqlParameter("@name", request.name),
            new SqlParameter("@email", request.email),
            new SqlParameter("@newId", SqlDbType.Int) { Direction = ParameterDirection.Output }
        };

        await _context.ExecuteSqlRawAsync("EXEC @newId = dbo.AddStudent @studentID, @name, @email",
            parameters.ToArray(), cancellationToken);

        return (int)parameters.Last().Value;
    }


}
