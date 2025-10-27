using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class UpdateCourseDTO
    {
        public int ID { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;       

    }
}
