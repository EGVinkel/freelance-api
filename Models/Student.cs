using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Freelance_Api.Models
{
    public class Student
    {
        [BsonId] 
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Study { get; set; }
        public string Uni { get; set; }
        public int Semester { get; set; }
        public string Ranking { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}