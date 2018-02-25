using System;
using CoreAndMongoDB.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace CoreAndMongoDB.DbModels
{
    public class MongoDbContext
    {
        private IMongoDatabase _database = null;
        public MongoDbContext(IOptions<Settings> settings)
        {
            try
            {
                var client = new MongoClient(settings.Value.ConnectionString);
                if (client != null)
                    _database = client.GetDatabase(settings.Value.Database);
            }
            catch (Exception ex)
            {
                throw new Exception("Mongo Db Sunucusuna erişilemiyor", ex);
            }
        }
        public IMongoCollection<Contact> Contacts
        {
            get
            {
                return _database.GetCollection<Contact>("Contacts");
            }
        }
    }
}
