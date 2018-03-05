using MongoDB.Driver;
using System.Collections.Generic;
using CoreAndMongoDB.Model;
using System.Threading.Tasks;

namespace CoreAndMongoDB.IRepository
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> Get(string id);
        Task<bool> Add(Contact contact);
        Task<bool> Update(string id,Contact contact);
        Task<DeleteResult> Remove(string id);
        Task<DeleteResult> RemoveAll();
    }
}
