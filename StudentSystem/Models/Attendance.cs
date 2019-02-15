using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem.Models
{
    public class Attendance
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
        public DateTime dateOfAttendance;
        public bool AttendanceMark;
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId studend_id;

    }
}