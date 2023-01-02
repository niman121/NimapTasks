using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksInDotnet48
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext() : base("StudentDbContext")
        {
            
            
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
    }
}
