﻿using MongoDB.Bson;
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
        [DataType(DataType.Text,ErrorMessage ="Student name should only contain characters")]
        [Required(ErrorMessage = "Enter Your Name")] [MaxLength(20,ErrorMessage ="User name too long")]
        public string stuName { get; set; }
        [DataType(DataType.EmailAddress,ErrorMessage ="Email address not in correct Format")]
        //[BsonElement("email")]
        [Required]
        public string email { get; set; }
        [DataType(DataType.Password,ErrorMessage ="Password not in format")]
        [Required(ErrorMessage = "Set a Password")]
        //[BsonElement("pwd")]
        [MinLength(6,ErrorMessage ="Too short to be a password")]
        [MembershipPassword(
        MinRequiredNonAlphanumericCharacters = 1,
        MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
        ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc).",
        MinRequiredPasswordLength = 6
)]
        public string pwd { get; set; }
        //[BsonElement("mobNo")]
        [MaxLength(10,ErrorMessage ="Phone Number must have 10 digits")]
        [MinLength(10, ErrorMessage = "Phone Number must have 10 digits")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="Phone Number can't be characters")]
        [Required(ErrorMessage = "You must provide a phone number")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]

        public string mobNo { get; set; }

        //[BsonElement("Address")]
        [DataType(DataType.MultilineText,ErrorMessage = "Invalid address format ")] [Required(ErrorMessage = "Required")]
        public string Address { get; set; }

        public string changeTime = DateTime.Now.ToString();
        public string updateTime = DateTime.Now.ToString();
        public string deleteTime = DateTime.Now.ToString();
        public string CreateTime = DateTime.Now.ToString();



    }
}