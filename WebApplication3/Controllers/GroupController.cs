using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.Repositories;
using WebApplication3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication3.Controllers
{
    public class GroupController : Controller
    {
        private IGroupRepository group;
        private ISchoolRepository school;
        public GroupController(IGroupRepository group, ISchoolRepository school)
        {
            this.school=school;
            this.group = group;
        }
        // GET: GroupController
        public ActionResult Index()
        {
            ViewBag.SchoolID = new SelectList(school.GetAll(), "SchoolID", "SchoolName");
            return View(group.GetAll());
        }
        public ActionResult Search( int schoolid)
        {
            IList<Group> result = group.GetAll();
            if (schoolid != null)
                result = group.GetGrroupsBySchoolID(schoolid);
            ViewBag.SchoolID = new SelectList(school.GetAll(), "SchoolID", "SchoolName");
            return View("Index", result);
        }
        // GET: GroupController/Details/5
        public ActionResult Details(int id)
        {
            Group g = group.getByid(id);
            return View(g);
        }

        // GET: GroupController/Create
        public ActionResult Create()
        {
            ViewBag.SchoolID = new SelectList(school.GetAll(), "SchoolID", "SchoolName");
            return View();
        }

        // POST: GroupController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Group g)
        {
            try
            {
                group.Add(g);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GroupController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.SchoolID = new SelectList(school.GetAll(), "SchoolID", "SchoolName");
            Group g= group.getByid(id);
            return View(g);
        }

        // POST: GroupController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Group g)
        {
            try
            {
                group.Edit(g);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
                return View();
            }
        }

        // GET: GroupController/Delete/5
        public ActionResult Delete(int id)
        {
            Group g = group.getByid(id);
            return View(g);
        }

        // POST: GroupController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Group collection)
        {
            try
            {
                group.Delete(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
