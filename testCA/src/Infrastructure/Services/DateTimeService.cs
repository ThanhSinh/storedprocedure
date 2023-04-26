using testCA.Application.Common.Interfaces;

namespace testCA.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
