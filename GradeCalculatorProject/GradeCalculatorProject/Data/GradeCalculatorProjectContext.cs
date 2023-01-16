using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GradeCalculatorProject.Models;

namespace GradeCalculatorProject.Data
{
    public class GradeCalculatorProjectContext : DbContext
    {
        public GradeCalculatorProjectContext (DbContextOptions<GradeCalculatorProjectContext> options)
            : base(options)
        {
        }

        public DbSet<GradeCalculatorProject.Models.StudentModel> StudentModel { get; set; } = default!;
    }
}
