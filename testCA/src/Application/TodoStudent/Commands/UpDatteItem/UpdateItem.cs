using testCA.Application.Common.Exceptions;
using testCA.Application.Common.Interfaces;
using testCA.Domain.Entities;
using MediatR;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;

namespace testCA.Application.TodoStudent.Commands.UpDatteItem;

public record UpdateItem : IRequest
{
    public int Id { get; init; }
    public int studentId { get; init; }
    public string name { get; init; }
    public string email { get; init; }
}

public class UpdateItemHandler : IRequestHandler<UpdateItem>
{
    private readonly IApplicationDbContext _context;

    public UpdateItemHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateItem request, CancellationToken cancellationToken)
    {
        var parameters = new[]
        {
        new SqlParameter("@Id", request.Id),
         new SqlParameter("@studentId", request.studentId),
        new SqlParameter("@name", request.name),
        new SqlParameter("@email", request.email),
    };

        await _context.ExecuteSqlRawAsync("EXEC dbo.UpdateStudent @Id, @studentId, @name, @email",
            parameters, cancellationToken);

        return Unit.Value;
    }

}
