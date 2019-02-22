using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB;
using StudentSystem.Properties;

namespace StudentSystem.Models
{
    public class mongoConnection
    {
        public MongoDatabase db;
        public mongoConnection()
        {
            var client = new MongoClient(Settings.Default.connString);
            var server =  client.GetServer();
            server.Connect();
            db = server.GetDatabase(Settings.Default.dbName);

        }
        public MongoCollection<Student> MCollection => db.GetCollection<Student>("STUDENT");
        public MongoCollection<School> SchoolCollection => db.GetCollection<School>("SCHOOL");
        public MongoCollection<CollectionOfClasses> classCollection => db.GetCollection<CollectionOfClasses>("CLASSES");
        public MongoCollection<Attendance> Attendance => db.GetCollection<Attendance>("ATTENDANCE");
        public MongoCollection<User> Users => db.GetCollection<User>("USER");

    }
}