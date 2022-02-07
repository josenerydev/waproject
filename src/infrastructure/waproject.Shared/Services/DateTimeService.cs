using waproject.Application.Common.Interfaces;

namespace waproject.Shared.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
