using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Freelance_Api.Models
{
    public class Student
    {
        [BsonId] 
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public string study { get; set; }
        public string uni { get; set; }
        public int semester { get; set; }
        public string ranking { get; set; }
        DateTime createdOn { get; set; }
        DateTime modifiedOn { get; set; }
    }
}