using System.Collections.Generic;
using Freelance_Api.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Freelance_Api.Services
{
    public class JobService 
    {
        private readonly IMongoCollection<Job> _jobs;

        public JobService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _jobs = database.GetCollection<Job>(settings.JobCollectionName);
        }

        public List<Job> Get() =>
            _jobs.Find(job => true).ToList();

        public Job Get(string id) =>
            _jobs.Find(student => student.Id == id).FirstOrDefault();

        public Job Create(Job job)
        {
            job.Id = ObjectId.GenerateNewId().ToString();
            _jobs.InsertOne(job);
            return job;
        }

        public void Update(string id, Job jobin) =>
            _jobs.ReplaceOne(job => job.Id == id, jobin);

        public void Remove(Job jobin) =>
            _jobs.DeleteOne(job => job.Id == jobin.Id);

        public void Remove(string id) =>
            _jobs.DeleteOne(job => job.Id == id);
    }
}