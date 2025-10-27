using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Student
    {
        public int ID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string IdentityNumber { get; set; }
        public required string MobileNumber { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>(); 
    }
}
