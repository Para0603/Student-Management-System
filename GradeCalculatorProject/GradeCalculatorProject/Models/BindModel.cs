using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace GradeCalculatorProject.Models
{
    public class BindModel
    {
        [DisplayName("Student RegisterNumber")]
        public int Student_Regno { get; set; }

        public String? Student_Name { get; set; }
        public string? Student_Dept { get; set; }
        public char? Grade { get; set; }
        public IEnumerable<SelectListItem>? ListOfStudents { get; set; }

    }
}
