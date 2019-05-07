using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace _01ConsoleApp
{
    public class Usuario
    {
        [BsonId()]
        public ObjectId ID { get; set; }

        [BsonElement("nome")]        
        public string Nome { get; set; }

        [BsonElement("email")]        
        public string Email { get; set; }
    }
}