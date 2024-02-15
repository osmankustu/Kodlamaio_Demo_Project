using KodlamaIo.Business.DTOs.CourseDTOs;
using KodlamaIo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Business.DTOs.InstructorDTOs
{
    public class InstructorViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<CourseViewModel> Courses { get; set; }
    }
}
