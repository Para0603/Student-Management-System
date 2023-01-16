using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GradeCalculatorProject.Data;
using GradeCalculatorProject.Models;
using Microsoft.Extensions.Hosting;

namespace GradeCalculatorProject.Controllers
{
    public class StudentsController : Controller
    {
        private readonly GradeCalculatorProjectContext _context;

     
        private readonly IWebHostEnvironment _hostEnvironment;

        public StudentsController(GradeCalculatorProjectContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Students
        public async Task<IActionResult> Index(int? SearchRegno)
        {
            ViewData["CurrentFilter"] = SearchRegno;
            var query = from b in _context.StudentModel select b;
            if (SearchRegno != null)
            {
                query = query.Where(b => b.Student_Regno == SearchRegno);

            }
            return View(query);
             //return View(await _context.StudentModel.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentModel == null)
            {
                return NotFound();
            }

            var studentModel = await _context.StudentModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentModel == null)
            {
                return NotFound();
            }

            return View(studentModel);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Student_Regno,Student_Name,Student_Dept,Subject1_Mark,Subject2_Mark,Subject3_Mark,Total_Mark,Average_Mark,Grade,Eligibility,ImageFile")] StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                studentModel.Total_Mark = studentModel.Subject1_Mark + studentModel.Subject2_Mark + studentModel.Subject3_Mark;
                studentModel.Average_Mark = (studentModel.Total_Mark) / 3;

                if (studentModel.Average_Mark >= 75)
                    studentModel.Grade = 'A';
                else
                    if (studentModel.Average_Mark >= 65)
                    studentModel.Grade = 'B';
                else
                     if (studentModel.Average_Mark >= 55)
                    studentModel.Grade = 'C';
                else
                        if (studentModel.Average_Mark >= 45)
                    studentModel.Grade = 'D';
                else
                    studentModel.Grade = 'F';

                
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(studentModel.ImageFile.FileName);
                string extension = Path.GetExtension(studentModel.ImageFile.FileName);
                studentModel.Image_Path = filename = filename + extension;
                string path = Path.Combine(wwwRootPath + "/image/", filename);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await studentModel.ImageFile.CopyToAsync(fileStream);
                }

                _context.Add(studentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentModel);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentModel == null)
            {
                return NotFound();
            }

            var studentModel = await _context.StudentModel.FindAsync(id);
            if (studentModel == null)
            {
                return NotFound();
            }
            return View(studentModel);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Student_Regno,Student_Name,Student_Dept,Subject1_Mark,Subject2_Mark,Subject3_Mark,Total_Mark,Average_Mark,Grade,ImageFile")] StudentModel studentModel)
        {
            if (id != studentModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                studentModel.Total_Mark = studentModel.Subject1_Mark + studentModel.Subject2_Mark + studentModel.Subject3_Mark;
                studentModel.Average_Mark = (studentModel.Total_Mark) / 3;

                if (studentModel.Average_Mark >= 75)
                    studentModel.Grade = 'A';
                else
                    if (studentModel.Average_Mark >= 65)
                    studentModel.Grade = 'B';
                else
                     if (studentModel.Average_Mark >= 55)
                    studentModel.Grade = 'C';
                else
                        if (studentModel.Average_Mark >= 45)
                    studentModel.Grade = 'D';
                else
                    studentModel.Grade = 'F';


                string wwwRootPath = _hostEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(studentModel.ImageFile.FileName);
                string extension = Path.GetExtension(studentModel.ImageFile.FileName);
                studentModel.Image_Path = filename = filename + extension;
                string path = Path.Combine(wwwRootPath + "/image/", filename);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await studentModel.ImageFile.CopyToAsync(fileStream);
                }

                try
                {
                    
                    _context.Update(studentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentModelExists(studentModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studentModel);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentModel == null)
            {
                return NotFound();
            }

            var studentModel = await _context.StudentModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentModel == null)
            {
                return NotFound();
            }

            return View(studentModel);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentModel == null)
            {
                return Problem("Entity set 'GradeCalculatorProjectContext.StudentModel'  is null.");
            }
            var studentModel = await _context.StudentModel.FindAsync(id);
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", studentModel.Image_Path);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            if (studentModel != null)
            {
                _context.StudentModel.Remove(studentModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentModelExists(int id)
        {
          return _context.StudentModel.Any(e => e.Id == id);
        }

        /*public JsonResult IsStudentRegisterNumberExist(int Student_Regno)
        {
            return Json(data: !_context.StudentModel.Any(e => e.Student_Regno == Student_Regno));
        }
        */
        public IActionResult BindData()
        {

            var studentsList = (from studentModel in _context.StudentModel
                                select new SelectListItem()
                                {
                                    Text = studentModel.Student_Regno.ToString(),
                                    Value = studentModel.Student_Name,
                                    
                                }).ToList();

            studentsList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });

            BindModel bindModel = new BindModel();
            bindModel.ListOfStudents = studentsList;

            return View(bindModel);
        }


        [HttpPost]
        public IActionResult BindData(BindModel bindModel)
        {
            var selectedValue = bindModel.Student_Name;
            ViewData["selectedValue"] = selectedValue;
            return View("Temp");

        }

        public IActionResult Temp()
        {
            return View();
        }
        

    }
}
