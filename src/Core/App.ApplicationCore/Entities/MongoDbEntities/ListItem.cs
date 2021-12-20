using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Application.ApplicationCore.Entities.MongoDbEntities
{
    public class ListItem
    {
        //Item Information

        [JsonIgnore]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string _Id { get; set; }
        public string ItemId { get; set; }
        public int ItemQuantity { get; set; }



    }
}
