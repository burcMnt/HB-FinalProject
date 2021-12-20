using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Entities.MongoDbEntities
{
    public class UserListItem
    {
        [JsonIgnore]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string _Id { get; set; }
        public string  UserId { get; set; }
        public string ItemId { get; set; }
        public int ItemQuantity { get; set; }
    }
}
