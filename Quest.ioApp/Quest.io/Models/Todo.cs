using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Quest.io.Models
{
    [BsonIgnoreExtraElements]
    public class Todo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("quest")]
        public string Quest { get; set; } = "Task";

        [BsonElement("desc")]
        public string Desc { get; set; } = "Description";

        [BsonElement("dl")]
        public DateTime DL { get; set; } 


    }
}
