using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class CreateCourseDTO
    {
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;       
    }
}
