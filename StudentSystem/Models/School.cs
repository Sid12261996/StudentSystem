using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentSystem.Models
{
    public class School
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
      
        [Required(ErrorMessage = "Mention your School Name")]
        public string SchoolName;
       
        
    }
}