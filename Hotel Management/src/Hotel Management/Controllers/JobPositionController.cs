using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class JobPositionController : Controller
    {
        private ApplicationDbContext _context;

        public JobPositionController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: JobPosition
        public IActionResult Index()
        {
            return View(_context.JobPosition.ToList());
        }

        // GET: JobPosition/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            JobPosition jobPosition = _context.JobPosition.Single(m => m.ID == id);
            if (jobPosition == null)
            {
                return HttpNotFound();
            }

            return View(jobPosition);
        }

        // GET: JobPosition/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobPosition/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JobPosition jobPosition)
        {
            if (ModelState.IsValid)
            {
                _context.JobPosition.Add(jobPosition);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobPosition);
        }

        // GET: JobPosition/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            JobPosition jobPosition = _context.JobPosition.Single(m => m.ID == id);
            if (jobPosition == null)
            {
                return HttpNotFound();
            }
            return View(jobPosition);
        }

        // POST: JobPosition/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(JobPosition jobPosition)
        {
            if (ModelState.IsValid)
            {
                _context.Update(jobPosition);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobPosition);
        }

        // GET: JobPosition/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            JobPosition jobPosition = _context.JobPosition.Single(m => m.ID == id);
            if (jobPosition == null)
            {
                return HttpNotFound();
            }

            return View(jobPosition);
        }

        // POST: JobPosition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            JobPosition jobPosition = _context.JobPosition.Single(m => m.ID == id);
            _context.JobPosition.Remove(jobPosition);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
