using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class ChargeBackController : Controller
    {
        private ApplicationDbContext _context;

        public ChargeBackController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ChargeBack
        public IActionResult Index()
        {
            var applicationDbContext = _context.ChargeBack.Include(c => c.CustomerGuest).Include(c => c.Invoice);
            return View(applicationDbContext.ToList());
        }

        // GET: ChargeBack/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ChargeBack chargeBack = _context.ChargeBack.Single(m => m.ID == id);
            if (chargeBack == null)
            {
                return HttpNotFound();
            }

            return View(chargeBack);
        }

        // GET: ChargeBack/Create
        public IActionResult Create()
        {
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerFullName");
            ViewData["InvoiceID"] = new SelectList(_context.Set<Invoice>(), "ID", "Invoice");
            return View();
        }

        // POST: ChargeBack/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ChargeBack chargeBack)
        {
            if (ModelState.IsValid)
            {
                _context.ChargeBack.Add(chargeBack);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CustomerGuestID"] = new SelectList(_context.Set<CustomerGuest>(), "ID", "CustomerGuest", chargeBack.CustomerGuestID);
            ViewData["InvoiceID"] = new SelectList(_context.Set<Invoice>(), "ID", "Invoice", chargeBack.InvoiceID);
            return View(chargeBack);
        }

        // GET: ChargeBack/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ChargeBack chargeBack = _context.ChargeBack.Single(m => m.ID == id);
            if (chargeBack == null)
            {
                return HttpNotFound();
            }
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerFullName");
            ViewData["InvoiceID"] = new SelectList(_context.Set<Invoice>(), "ID", "Invoice", chargeBack.InvoiceID);
            return View(chargeBack);
        }

        // POST: ChargeBack/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ChargeBack chargeBack)
        {
            if (ModelState.IsValid)
            {
                _context.Update(chargeBack);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CustomerGuestID"] = new SelectList(_context.Set<CustomerGuest>(), "ID", "CustomerGuest", chargeBack.CustomerGuestID);
            ViewData["InvoiceID"] = new SelectList(_context.Set<Invoice>(), "ID", "Invoice", chargeBack.InvoiceID);
            return View(chargeBack);
        }

        // GET: ChargeBack/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ChargeBack chargeBack = _context.ChargeBack.Single(m => m.ID == id);
            if (chargeBack == null)
            {
                return HttpNotFound();
            }

            return View(chargeBack);
        }

        // POST: ChargeBack/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ChargeBack chargeBack = _context.ChargeBack.Single(m => m.ID == id);
            _context.ChargeBack.Remove(chargeBack);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
