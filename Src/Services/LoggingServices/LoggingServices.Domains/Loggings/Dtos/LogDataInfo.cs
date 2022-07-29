using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LoggingServices.Domains.Loggings.Dtos
{
    public class LogDataInfo
    {      
       
        public string ControllerName { get; set; }

   
        public string ActionName { get; set; }

      
        public string LogLevel { get; set; }

   
        public string Message { get; set; }
    }

}

