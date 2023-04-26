using testCA.Application.Common.Exceptions;
using testCA.Application.Common.Interfaces;
using testCA.Domain.Entities;
using testCA.Domain.Events;
using MediatR;
using Microsoft.Data.SqlClient;

namespace testCA.Application.TodoStudent.Commands.DeleteItem;

public record DeleteItem(int Id) : IRequest;

public class DeleteItemHandler : IRequestHandler<DeleteItem>
{
    private readonly IApplicationDbContext _context;

    public DeleteItemHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /* public async Task<Unit> Handle(DeleteItem request, CancellationToken cancellationToken)
     {
         var entity = await _context.Students
             .FindAsync(new object[] { request.Id }, cancellationToken);

         if (entity == null)
         {
             throw new NotFoundException(nameof(Student), request.Id);
         }

         _context.Students.Remove(entity);

         //entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

         await _context.SaveChangesAsync(cancellationToken);

         return Unit.Value;
     }*/
    public async Task<Unit> Handle(DeleteItem request, CancellationToken cancellationToken)
    {
        var parameters = new[]
        {
        new SqlParameter("@Id", request.Id),
    };

        await _context.ExecuteSqlRawAsync("EXEC dbo.DeleteStudent @Id",
            parameters, cancellationToken);

        return Unit.Value;
    }

}
