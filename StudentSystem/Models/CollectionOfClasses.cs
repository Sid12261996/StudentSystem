using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem.Models
{
    public class CollectionOfClasses
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
        public string ClassName;
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId StudentId { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId SchoolId { get; set; }

    }
}