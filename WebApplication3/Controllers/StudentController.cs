using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.Repositories;
using WebApplication3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication3.Controllers
{
    [Authorize (Roles = "Admin,Manager")]
    public class StudentController : Controller
    {
        private IStudentRepository etudiant;
        private ISchoolRepository school;
        private IGroupRepository group;
        public StudentController(IStudentRepository etudiant, ISchoolRepository school, IGroupRepository group)
        {
            this.group = group;
            this.etudiant = etudiant;   
            this.school = school;
        }
        // GET: StudentController
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.SchoolID = new SelectList(school.GetAll(), "SchoolID", "SchoolName");

            IList< Student > e= etudiant.GetAll();
            return View(e);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {

            Student e = etudiant.GetById(id);
            return View(e);
        }

        // GET: StudentController/Create
        public ActionResult Create(int idSChool)
        {
            ViewBag.SchoolID = new SelectList(school.GetAll(), "SchoolID","SchoolName");

            return View();
        }
        public ActionResult searchGroup(Student s)
        {
            ViewBag.SchoolID = new SelectList(school.GetAll(), "SchoolID", "SchoolName");
            ViewBag.GroupID = new SelectList(group.GetGrroupsBySchoolID(s.SchoolID), "Id", "Name");
            return View("Views/Student/Create.cshtml",s);

        }
        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student s)
        {
            try
            {
                etudiant.Add(s);
                return RedirectToAction(nameof(Index));


            }
            catch
            {
                ViewBag.SchoolID = new SelectList(school.GetAll(), "SchoolID", "SchoolName");
                ViewBag.GroupID = new SelectList(group.GetGrroupsBySchoolID(s.SchoolID), "Id", "Name");
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.SchoolID = new SelectList(school.GetAll(), "SchoolID", "SchoolName");

            Student e = etudiant.GetById(id);
            return View(e);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student s)
        {
            try
            {
                etudiant.Edit(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            Student e = etudiant.GetById(id);

            return View(e);
        }
        public ActionResult Search(string name, int schoolid)
        {
            var result = etudiant.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = etudiant.FindByName(name);
            else
            if (schoolid != null)
                result = etudiant.GetStudentsBySchoolID(schoolid);
            ViewBag.SchoolID = new SelectList(school.GetAll(), "SchoolID", "SchoolName");
            return View("Index", result);
        }
        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Student s)
        {
            try
            {
                etudiant.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
