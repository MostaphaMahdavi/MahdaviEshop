using System;
using MahdaviEshop.Framework.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LoggingServices.Domains.Loggings.Entities
{
    public class LogData//:BaseEntity<Guid>
    {

        private LogData()
        {
            Id = Guid.NewGuid().ToString().Replace("-","");
            CreatedDate = DateTime.Now;
        }
        private LogData(string controllerName, string actionName, string logLevel, string message)
        {
            
            Id = Guid.NewGuid().ToString().Replace("-", ""); ;
            CreatedDate = DateTime.Now;
            ControllerName = controllerName;
            ActionName = actionName;
            LogLevel = LogLevel;
            Message = message;
        }

        [BsonId]
       // [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; }

        [BsonElement("controllerName")]
        public string ControllerName { get;private set; }

        [BsonElement("actionName")]
        public string ActionName { get;private set; }

        [BsonElement("logLevel")]
        public string LogLevel { get;private set; }

        [BsonElement("message")]
        public string Message { get;private set; }



        public static LogData Create(string controllerName,string actionName,string logLevel,string message)
        {
            return new LogData
            {
                ControllerName=controllerName,
                ActionName=actionName,
                LogLevel=logLevel,
                Message=message,

            };
        }
    }
}

