using System;
namespace MahdaviEshop.Framework.Dtos.Settings
{
    public class SiteSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int IssuedAt { get; set; }
        public int NotBefore { get; set; }
        public int Expires { get; set; }
        public string SecurityKey{ get; set; }
        public MongoDBSettings MongoDBSettings { get; set; }
    }
    public class MongoDBSettings
    {
        public string MongoConnectionString { get; set; }
        public string MongoDatabaseName { get; set; }
    }
}

