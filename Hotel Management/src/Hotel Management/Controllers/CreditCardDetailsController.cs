using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class CreditCardDetailsController : Controller
    {
        private ApplicationDbContext _context;

        public CreditCardDetailsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CreditCardDetails
        public IActionResult Index()
        {
            var applicationDbContext = _context.CreditCardDetails.Include(c => c.CustomerGuest);
            return View(applicationDbContext.ToList());
        }

        // GET: CreditCardDetails/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CreditCardDetails creditCardDetails = _context.CreditCardDetails.Single(m => m.ID == id);
            if (creditCardDetails == null)
            {
                return HttpNotFound();
            }

            return View(creditCardDetails);
        }

        // GET: CreditCardDetails/Create
        public IActionResult Create()
        {
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest.OrderByDescending(k => k.ID), "ID", "CustomerFullName");
            return View();
        }

        // POST: CreditCardDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreditCardDetails creditCardDetails)
        {
            if (ModelState.IsValid)
            {
                _context.CreditCardDetails.Add(creditCardDetails);
                _context.SaveChanges();
                return RedirectToAction("Tasks", "Booking");
            }
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerGuest", creditCardDetails.CustomerGuestID);
            return View(creditCardDetails);
        }

        // GET: CreditCardDetails/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CreditCardDetails creditCardDetails = _context.CreditCardDetails.Single(m => m.ID == id);
            if (creditCardDetails == null)
            {
                return HttpNotFound();
            }
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerFullName");
            return View(creditCardDetails);
        }

        // POST: CreditCardDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CreditCardDetails creditCardDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Update(creditCardDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerGuest", creditCardDetails.CustomerGuestID);
            return View(creditCardDetails);
        }

        // GET: CreditCardDetails/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CreditCardDetails creditCardDetails = _context.CreditCardDetails.Single(m => m.ID == id);
            if (creditCardDetails == null)
            {
                return HttpNotFound();
            }

            return View(creditCardDetails);
        }

        // POST: CreditCardDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            CreditCardDetails creditCardDetails = _context.CreditCardDetails.Single(m => m.ID == id);
            _context.CreditCardDetails.Remove(creditCardDetails);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
