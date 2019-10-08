using Freelance_Api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Freelance_Api.DatabaseAccess
{
    public class Dao: IDao
    {
        private IMongoDatabase _db;

        public Dao(IOptions<Settings> options, IMongoClient client)
        {
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Student> Students => _db.GetCollection<Student>("Student");
     
    }

  
}