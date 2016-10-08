using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class AvailabilityController : Controller
    {
        private ApplicationDbContext _context;

        public AvailabilityController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Availability
        public IActionResult Index()
        {
            return View(_context.Availability.ToList());
        }

        // GET: Availability/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Availability availability = _context.Availability.Single(m => m.ID == id);
            if (availability == null)
            {
                return HttpNotFound();
            }

            return View(availability);
        }

        // GET: Availability/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Availability/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Availability availability)
        {
            if (ModelState.IsValid)
            {
                _context.Availability.Add(availability);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(availability);
        }

        // GET: Availability/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Availability availability = _context.Availability.Single(m => m.ID == id);
            if (availability == null)
            {
                return HttpNotFound();
            }
            return View(availability);
        }

        // POST: Availability/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Availability availability)
        {
            if (ModelState.IsValid)
            {
                _context.Update(availability);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(availability);
        }

        // GET: Availability/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Availability availability = _context.Availability.Single(m => m.ID == id);
            if (availability == null)
            {
                return HttpNotFound();
            }

            return View(availability);
        }

        // POST: Availability/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Availability availability = _context.Availability.Single(m => m.ID == id);
            _context.Availability.Remove(availability);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
