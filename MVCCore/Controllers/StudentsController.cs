using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using SchoolService.Interfaces;

namespace MVCCore.Controllers
{
    #region snippet_ContextInController
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        #endregion
        // GET: Students
        public async Task<IActionResult> Index()
        {
            var studentResults = await _studentService.GetStudents();
            return View(studentResults);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var studentResults = await _studentService.GetStudent(id.Value);
            
            if (studentResults == null)
            {
                return NotFound();
            }

            return View(studentResults);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentDate,FirstMidName,LastName")] StudentDTO student)
        {
            if (ModelState.IsValid)
            {
                await _studentService.AddStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            var studentResults = await _studentService.GetStudent(id.Value);

            if (studentResults == null)
            {
                return NotFound();
            }
            return View(studentResults);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EnrollmentDate,FirstMidName,LastName")] StudentDTO studentDto)
        {
            if (id != studentDto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _studentService.EditStudent(studentDto);
                return RedirectToAction("Index");
            }
            return View(studentDto);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var studentResults = await _studentService.GetStudent(id.Value);

            if (studentResults == null)
            {
                return NotFound();
            }

            return View(studentResults);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _studentService.DeleteStudent(id);
            
            return RedirectToAction("Index");
        }

    }
}
