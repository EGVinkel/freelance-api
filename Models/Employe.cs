namespace DefaultNamespace
{
    public class Employe
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string logo { get; set; } // URL
        public string website { get; set; }
        public int size { get; set; }
    }
}