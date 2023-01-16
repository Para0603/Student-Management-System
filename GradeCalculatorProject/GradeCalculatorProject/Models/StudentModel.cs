using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradeCalculatorProject.Models
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Register Number Can't be Blank")]
        [Display(Name = "Registration Number")]
        //[Remote(action: "IsStudentRegisterNumberExist", "Students", ErrorMessage = "RegisterNumber already Exists")]
        public int Student_Regno { get; set; }
        [RegularExpression("[a-zA-Z][a-zA-Z]+[a-zA-Z]$", ErrorMessage = "Name can't be blank")]
        [Required(ErrorMessage = "Name Can't be Blank")]
        [Display(Name = "Name")]
        public string? Student_Name { get; set; }
        [RegularExpression("[a-zA-Z][a-zA-Z]+[a-zA-Z]$", ErrorMessage = "Department can't be blank")]
        [Required(ErrorMessage = "Department Can't be Blank")]
        [Display(Name = "Department")]
        public string? Student_Dept { get; set; }
        [Required(ErrorMessage = "First Year Mark Can't be Blank")]
        [Range(0, 100, ErrorMessage = "Mark Should be between 0 and 100")]
        [Display(Name = "First Year Percentage")]
        public int Subject1_Mark { get; set; }
        [Required(ErrorMessage = "Second Year Mark Can't be Blank")]
        [Range(0, 100, ErrorMessage = "Mark Should be between 0 and 100")]
        [Display(Name = "Second Year Percentage")]
        public int Subject2_Mark { get; set; }
        [Required(ErrorMessage = "Third Year Mark Can't be Blank")]
        [Range(0, 100, ErrorMessage = "Mark Should be between 0 and 100")]
        [Display(Name = "Third Year Percentage")]
        public int Subject3_Mark { get; set; }
        [Display(Name = "Total")]
        public int Total_Mark { get; set; }
        [Display(Name = "Average")]
        public int Average_Mark { get; set; }

        public char Grade { get; set; }
        
       
        [Display(Name = "Upload Image")]
        public string? Image_Path { get; set; }

        [Required]
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

    }
}
