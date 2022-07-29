using System;
using LoggingServices.Domains.Loggings.Entities;

namespace LoggingServices.Domains.Loggings.Repositories
{
    public interface ILogRepository
    {
        Task<List<LogData>> GetAllAsync();
        Task<LogData> GetByIdAsync(string id);
        Task CreateLogAsync(LogData newLogData);
        Task UpdateLogAsync(LogData logToUpdate);
        Task DeleteLogAsync(string id);
    }
}

