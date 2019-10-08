using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Freelance_Api.Models
{
    public class Student
    {
        [BsonId] 
        public ObjectId Id {get; set; }
        public string Name { get; set; }
        public string Study { get; set; }
        public string Uni { get; set; }
        public int Semester { get; set; }
        public string Ranking { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }
    }
}