using CoreAndMongoDB.DbModels;
using CoreAndMongoDB.IRepository;
using CoreAndMongoDB.Model;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndMongoDB.Repository
{
    public class ContactRepository:IContactRepository
    {

        private readonly MongoDbContext _context = null;
        
        public ContactRepository(IOptions<Settings> settings)
        {
            _context = new MongoDbContext(settings);
        }

        public async Task<bool> Add(Contact contact)
        {
            bool isAdded;
            try
            {
                await _context.Contacts.InsertOneAsync(contact);
                isAdded = true;
            }
            catch (Exception)
            {
                isAdded = false;
            }
            return isAdded;

        }

        public async Task<Contact> Get(string id)
        {
            var contact = Builders<Contact>.Filter.Eq("ID", id);
            return await _context.Contacts.Find(contact).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _context.Contacts.Find(x => true).ToListAsync();
        }

        public async Task<DeleteResult> Remove(string id)
        {
            return await _context.Contacts.DeleteOneAsync(Builders<Contact>.Filter.Eq("ID", id));
        }

        public async Task<DeleteResult> RemoveAll()
        {
            return await _context.Contacts.DeleteManyAsync(new BsonDocument());
        }

        public async Task<bool> Update(string id,Contact contact)
        {
            bool isUpdated;
            try
            {
                await _context.Contacts.ReplaceOneAsync(c => c.ID == id, contact);
                isUpdated = true;
            }
            catch (Exception)
            {
                isUpdated = false;
            }

         
            return isUpdated;
        }
    }
}
