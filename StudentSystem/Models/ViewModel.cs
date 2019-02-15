using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem.Models
{
    using StudentSystem.Models;
    public class ViewModel
    {
        public IEnumerable <Student> students { get; set; }
        public Attendance attendance = new Attendance();
        public IEnumerable<School> schools { get; set; }




    }
}