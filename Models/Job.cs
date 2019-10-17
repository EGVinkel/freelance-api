namespace Freelance_Api.Models
{
    public class Job
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public int salary { get; set; }
        public string location { get; set; }
        public bool monthlyOrHourlyPaid { get; set; }
        DateTime jobStart { get; set; }
        DateTime jobEnd { get; set; }
    }
}