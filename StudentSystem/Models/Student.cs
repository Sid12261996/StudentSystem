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
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
        //[BsonElement("stuName")]
        [DataType(DataType.Text)]
        [Required] [MaxLength(20)]
        public string stuName { get; set; }
        [DataType(DataType.EmailAddress)]
        //[BsonElement("email")]
        [Required]
        public string email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Required")]
        //[BsonElement("pwd")]
        [MinLength(6)]
        public string pwd { get; set; }
        //[BsonElement("mobNo")]
        [MaxLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string mobNo { get; set; }

        //[BsonElement("Address")]
        [DataType(DataType.MultilineText)] [Required(ErrorMessage = "Required")]
        public string Address { get; set; }
        
        public string changeTime = DateTime.Now.ToString();
      


    }
}