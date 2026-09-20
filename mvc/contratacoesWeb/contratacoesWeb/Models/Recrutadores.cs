
//Recrutadores
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;

namespace contratacoesWeb.Models
{
    [CollectionName("Recrutadores")]
    public class Recrutadores 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
    }
}
