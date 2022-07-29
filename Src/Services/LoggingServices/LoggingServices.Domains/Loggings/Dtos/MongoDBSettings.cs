using System;
namespace LoggingServices.Domains.Loggings.Dtos
{
    public class MongoDBSettings
    {
        public string MongoConnectionString { get; set; }
        public string MongoDatabaseName { get; set; }
    }
}

