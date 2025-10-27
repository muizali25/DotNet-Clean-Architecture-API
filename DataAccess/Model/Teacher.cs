using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Teacher
    {
        [Key]
        public int ID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string IdentityNumber { get; set; }
        public required string MobileNumber { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }   
}
