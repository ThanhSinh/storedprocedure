using testCA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using testCA.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Microsoft.Data.SqlClient;

namespace testCA.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<Student> Students { get; }

    
    Task ExecuteSqlRawAsync(string sql, SqlParameter[] parameters, CancellationToken cancellationToken);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
