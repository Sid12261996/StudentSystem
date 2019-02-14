using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace StudentSystem.Models
{
    public class LoginUser
    {
        [DataType(DataType.EmailAddress, ErrorMessage = "Email address not in correct Format")]
        [BsonElement("email")]
        [Required(ErrorMessage = "Email cannot be left blank")]
        public string Email { get; set; }

        [DataType(DataType.Password, ErrorMessage = "Password not in format")]
        [Required(ErrorMessage = "Set a Password")]
        [BsonElement("pwd")]
        [MinLength(6, ErrorMessage = "Too short to be a password")]
        [MembershipPassword(
            MinRequiredNonAlphanumericCharacters = 1,
            MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
            ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc).",
            MinRequiredPasswordLength = 6
         )]
        public string Password { get; set; }
    }
}