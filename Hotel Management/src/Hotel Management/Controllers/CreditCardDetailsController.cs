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
            return View(_context.CreditCardDetails.ToList());
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
                return RedirectToAction("Index");
            }
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
