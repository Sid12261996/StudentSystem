using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentSystem.Models
{
    public class Student
    {
        [BsonId]
        public ObjectId _id { get; set; }
        [Required][BsonElement("stuName")]
        [DataType(DataType.Text)]
        public string stuName { get; set; }
        [Required][DataType(DataType.EmailAddress)]
        [BsonElement("email")]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [BsonElement("pwd")]
        public string pwd { get; set; }
        [Required]
        [BsonElement("mobNo")]
        [DataType(DataType.PhoneNumber)]
        public string mobNo { get; set; }
        [Required]
        [BsonElement("Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }


    }
}