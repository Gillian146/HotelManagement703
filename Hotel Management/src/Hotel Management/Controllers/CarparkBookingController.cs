using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class CarparkBookingController : Controller
    {
        private ApplicationDbContext _context;

        public CarparkBookingController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CarparkBooking
        public IActionResult Index()
        {
            var applicationDbContext = _context.CarparkBooking.Include(c => c.Carpark).Include(c => c.CustomerGuest).OrderBy(d=>d.Date);
            return View(applicationDbContext.ToList());
        }
        // GET: CarparkBooking
        public IActionResult Show()
        {
            var applicationDbContext = _context.CarparkBooking.Include(c => c.Carpark).Include(c => c.CustomerGuest);
            ViewData["CarparkID"] = new SelectList(_context.Carpark, "ID", "CarparkNumber");
            return View(applicationDbContext.ToList());
        }
        // GET: CarparkBooking/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CarparkBooking carparkBooking = _context.CarparkBooking.Single(m => m.ID == id);
            if (carparkBooking == null)
            {
                return HttpNotFound();
            }

            return View(carparkBooking);
        }

        // GET: CarparkBooking/Create
        public IActionResult Create()
        {
            ViewData["CarparkID"] = new SelectList(_context.Carpark, "ID", "CarparkNumber");
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerFullName");
            return View();
        }

        // POST: CarparkBooking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarparkBooking carparkBooking)
        {
            if (ModelState.IsValid)
            {
                _context.CarparkBooking.Add(carparkBooking);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CarparkID"] = new SelectList(_context.Carpark, "ID", "Carpark", carparkBooking.CarparkID);
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerGuest", carparkBooking.CustomerGuestID);
            return View(carparkBooking);
        }

        // GET: CarparkBooking/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CarparkBooking carparkBooking = _context.CarparkBooking.Single(m => m.ID == id);
            if (carparkBooking == null)
            {
                return HttpNotFound();
            }
            ViewData["CarparkID"] = new SelectList(_context.Carpark, "ID", "CarparkNumber");
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerFullName");
            return View(carparkBooking);
        }

        // POST: CarparkBooking/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CarparkBooking carparkBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Update(carparkBooking);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CarparkID"] = new SelectList(_context.Carpark, "ID", "Carpark", carparkBooking.CarparkID);
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerGuest", carparkBooking.CustomerGuestID);
            return View(carparkBooking);
        }

        // GET: CarparkBooking/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CarparkBooking carparkBooking = _context.CarparkBooking.Single(m => m.ID == id);
            if (carparkBooking == null)
            {
                return HttpNotFound();
            }

            return View(carparkBooking);
        }

        // POST: CarparkBooking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            CarparkBooking carparkBooking = _context.CarparkBooking.Single(m => m.ID == id);
            _context.CarparkBooking.Remove(carparkBooking);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
