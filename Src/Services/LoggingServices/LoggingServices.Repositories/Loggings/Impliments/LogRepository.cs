using System;
using LoggingServices.Domains.Loggings.Entities;
using LoggingServices.Domains.Loggings.Repositories;
using MongoDB.Driver;

namespace LoggingServices.Repositories.Loggings.Impliments
{
    public class LogRepository: ILogRepository
    {
        private readonly IMongoCollection<LogData> _logData;
        public LogRepository(IMongoDatabase mongoDatabase)
        {
            _logData = mongoDatabase.GetCollection<LogData>("LogData");

        }

        public async Task<List<LogData>> GetAllAsync()
        {
            return await _logData.Find(_ => true).ToListAsync();
        }

        public async Task<LogData> GetByIdAsync(string id)
        {
            return await _logData.Find(_ => _.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateLogAsync(LogData newLogData)
        {
            await _logData.InsertOneAsync(newLogData);
        }

        public async Task UpdateLogAsync(LogData logTOUpdate)
        {
            await _logData.ReplaceOneAsync(x => x.Id == logTOUpdate.Id, logTOUpdate);
        }

        public async Task DeleteLogAsync(string id)
        {
            await _logData.DeleteOneAsync(x => x.Id == id);
        }
    }
}

