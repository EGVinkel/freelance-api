using Freelance_Api.Models;
using MongoDB.Driver;

namespace Freelance_Api.DatabaseAccess
{
    public interface IDao
    {
        IMongoCollection<Student> Students { get;}
    }
}