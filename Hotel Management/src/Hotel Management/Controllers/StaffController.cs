using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel Management.Controllers
{
    public class StaffController : Controller
    {
        private ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Staff
        public IActionResult Index()
        {
            return View(_context.Staff.ToList());
        }

        // GET: Staff/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Staff staff = _context.Staff.Single(m => m.ID == id);
            if (staff == null)
            {
                return HttpNotFound();
            }

            return View(staff);
        }

        // GET: Staff/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Staff.Add(staff);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        // GET: Staff/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Staff staff = _context.Staff.Single(m => m.ID == id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Staff/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Update(staff);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        // GET: Staff/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Staff staff = _context.Staff.Single(m => m.ID == id);
            if (staff == null)
            {
                return HttpNotFound();
            }

            return View(staff);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Staff staff = _context.Staff.Single(m => m.ID == id);
            _context.Staff.Remove(staff);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
