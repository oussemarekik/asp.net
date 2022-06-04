using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.Repositories;
using WebApplication3.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication3.Controllers
{
    [Authorize (Roles = "Admin,Manager")]
    public class SchoolController : Controller
    {
        private ISchoolRepository school;
        public SchoolController(ISchoolRepository school)
        {
            this.school = school;
        }
        [AllowAnonymous]
        // GET: SchoolController
        public ActionResult Index()
        {
            IList<School> l= school.GetAll();
            return View(l);
        }

        // GET: SchoolController/Details/5
        public ActionResult Details(int id)
        {
            School s =school.GetById(id);
            return View(s);
        }

        // GET: SchoolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(School s)
        {
            try
            {
                school.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Edit/5
        public ActionResult Edit(int id)
        {
            School s = school.GetById(id);

            return View(s);
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, School s)
        {
            try
            {
                school.Edit(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Delete/5
        public ActionResult Delete(int id)
        {
            School s = school.GetById(id);

            return View(s);
        }

        // POST: SchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, School s)
        {
            try
            {
                school.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
