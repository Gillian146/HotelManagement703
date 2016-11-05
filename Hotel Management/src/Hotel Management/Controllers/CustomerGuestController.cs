using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class CustomerGuestController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerGuestController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CustomerGuest
        public IActionResult Index()
        {
            var applicationDbContext = _context.CustomerGuest.Include(c => c.Agency).Include(c => c.Booking).Include(c => c.Company);
            return View(applicationDbContext.ToList());
        }

        // GET: CustomerGuest/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CustomerGuest customerGuest = _context.CustomerGuest.Single(m => m.ID == id);
            if (customerGuest == null)
            {
                return HttpNotFound();
            }

            return View(customerGuest);
        }

        // GET: CustomerGuest/Create
        public IActionResult Create()
        {
            ViewData["AgencyID"] = new SelectList(_context.Agency, "ID", "AgencyName");
            ViewData["CompanyID"] = new SelectList(_context.Company, "ID", "CompanyName");
            return View();
        }

        // POST: CustomerGuest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerGuest customerGuest)
        {
            if (ModelState.IsValid)
            {
                _context.CustomerGuest.Add(customerGuest);
                _context.SaveChanges();
                return RedirectToAction("Create", "Booking");
            }
            ViewData["AgencyID"] = new SelectList(_context.Agency, "ID", "AgencyName");
            return View(customerGuest);
        }
        // GET: Guest / Select
        public IActionResult Select()
        {            
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerFullName");
            return View();
        }
        // POST: Guest / Select
        [HttpPost]
        public IActionResult Select(int? id)
        {
            CustomerGuest customerGuest = _context.CustomerGuest.Single(m => m.ID == id);
            return RedirectToAction("Details");
        }

        // GET: CustomerGuest/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CustomerGuest customerGuest = _context.CustomerGuest.Single(m => m.ID == id);
            if (customerGuest == null)
            {
                return HttpNotFound();
            }
         
            ViewData["AgencyID"] = new SelectList(_context.Agency, "ID", "AgencyName", customerGuest.AgencyID);
            return View(customerGuest);
        }

        // POST: CustomerGuest/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerGuest customerGuest)
        {
            if (ModelState.IsValid)
            {
                _context.Update(customerGuest);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["AgencyID"] = new SelectList(_context.Agency, "ID", "Agency", customerGuest.AgencyID);
            return View(customerGuest);
        }

        // GET: CustomerGuest/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CustomerGuest customerGuest = _context.CustomerGuest.Single(m => m.ID == id);
            if (customerGuest == null)
            {
                return HttpNotFound();
            }

            return View(customerGuest);
        }

        // POST: CustomerGuest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            CustomerGuest customerGuest = _context.CustomerGuest.Single(m => m.ID == id);
            _context.CustomerGuest.Remove(customerGuest);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
