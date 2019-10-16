using System.Collections.Generic;
using Freelance_Api.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Freelance_Api.Services
{
    public class StudentService 
    {
        private readonly IMongoCollection<Student> _students;

        public StudentService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _students = database.GetCollection<Student>(settings.StudentCollectionName);
        }

        public List<Student> Get() =>
            _students.Find(student => true).ToList();

        public Student Get(string id) =>
            _students.Find(student => student.Id == id).FirstOrDefault();

        public Student Create(Student student)
        {
            student.Id = ObjectId.GenerateNewId().ToString();
            _students.InsertOne(student);
            return student;
        }

        public void Update(string id, Student studentin) =>
            _students.ReplaceOne(student => student.Id == id, studentin);

        public void Remove(Student studentin) =>
            _students.DeleteOne(student => student.Id == studentin.Id);

        public void Remove(string id) =>
            _students.DeleteOne(student => student.Id == id);
    }
}