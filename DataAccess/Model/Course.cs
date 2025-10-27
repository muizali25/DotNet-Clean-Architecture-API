using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
   public class Course
    {
        public int ID { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? TeacherID { get; set; }      
        public Teacher? Teacher { get; set; }       
        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
