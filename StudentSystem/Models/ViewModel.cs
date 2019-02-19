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
        public IEnumerable<Attendance> attendance { get; set; }
        public IEnumerable<School> schools { get; set; }
        public IEnumerable<CollectionOfClasses> classes { get; set; }



    }
}