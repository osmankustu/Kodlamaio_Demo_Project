using KodlamaIo.Business.DTOs.CourseCategoryDTOs;
using KodlamaIo.Business.DTOs.InstructorDTOs;
using KodlamaIo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Business.DTOs.CourseDTOs
{
    public class CourseViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public CourseCategoryViewModel  CourseCategory { get; set; }

        public InstructorViewModel Instructor { get; set; }
    }
}
