using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class StaffController : Controller
    {
        private ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;    
        }
        //Navigation Page
        public IActionResult Tasks()
        {
            return View();
        }

        // GET: Staff
        public IActionResult Index()
        {
            var applicationDbContext = _context.Staff.Include(s => s.Hotel).Include(s => s.JobPosition);
            return View(applicationDbContext.ToList());
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
            ViewData["HotelID"] = new SelectList(_context.Hotel, "ID", "Hotel");
            ViewData["JobPositionID"] = new SelectList(_context.JobPosition, "ID", "JobPosition");
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
            ViewData["HotelID"] = new SelectList(_context.Hotel, "ID", "Hotel", staff.HotelID);
            ViewData["JobPositionID"] = new SelectList(_context.JobPosition, "ID", "JobPosition", staff.JobPositionID);
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
            ViewData["HotelID"] = new SelectList(_context.Hotel, "ID", "Hotel", staff.HotelID);
            ViewData["JobPositionID"] = new SelectList(_context.JobPosition, "ID", "JobPosition", staff.JobPositionID);
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
            ViewData["HotelID"] = new SelectList(_context.Hotel, "ID", "Hotel", staff.HotelID);
            ViewData["JobPositionID"] = new SelectList(_context.JobPosition, "ID", "JobPosition", staff.JobPositionID);
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
