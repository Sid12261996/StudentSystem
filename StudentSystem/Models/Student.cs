using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

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
        [MembershipPassword(
        MinRequiredNonAlphanumericCharacters = 1,
        MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
        ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc).",
        MinRequiredPasswordLength = 6
)]
        public string pwd { get; set; }
        //[BsonElement("mobNo")]
        [MaxLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string mobNo { get; set; }

        //[BsonElement("Address")]
        [DataType(DataType.MultilineText)] [Required(ErrorMessage = "Required")]
        public string Address { get; set; }
        
        public string changeTime = DateTime.Now.ToString();
      
        public DateTime updateTime { get; set; }
        public DateTime deleteTime { get; set; }
        public DateTime CreateTime { get; set; }


    }
}