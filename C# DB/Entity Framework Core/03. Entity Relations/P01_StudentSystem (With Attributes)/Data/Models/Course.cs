using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            StudentsCourses = new List<StudentCourse>();
            Resources = new List<Resource>();
            Homeworks = new List<Homework>();
        }

        [Required]
        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(80)]
        [Unicode]
        public string Name { get; set; }

        [Unicode]
        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        
        public ICollection<StudentCourse> StudentsCourses { get; set; }

        
        public ICollection<Resource> Resources { get; set; }

        public ICollection<Homework> Homeworks { get; set; }
    }
}
