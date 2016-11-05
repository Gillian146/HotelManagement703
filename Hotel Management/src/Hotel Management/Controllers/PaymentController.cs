using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class PaymentController : Controller
    {
        private ApplicationDbContext _context;

        public PaymentController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Payment
        public IActionResult Index()
        {
            var applicationDbContext = _context.Payment.Include(p => p.CreditCardDetails).Include(p => p.Invoice);
            return View(applicationDbContext.ToList());
        }

        // GET: Payment/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Payment payment = _context.Payment.Single(m => m.ID == id);
            if (payment == null)
            {
                return HttpNotFound();
            }

            return View(payment);
        }

        // GET: Payment/Create
        public IActionResult Create()
        {
            ViewData["CreditCardDetailsID"] = new SelectList(_context.CreditCardDetails, "ID", "CreditCardNumbers");
            ViewData["InvoiceID"] = new SelectList(_context.Invoice, "ID", "ID");
            return View();
        }

        // POST: Payment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Payment payment)
        {
            if (ModelState.IsValid)
            {
                _context.Payment.Add(payment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CreditCardDetailsID"] = new SelectList(_context.CreditCardDetails, "ID", "CreditCardDetails", payment.CreditCardDetailsID);
            ViewData["InvoiceID"] = new SelectList(_context.Invoice, "ID", "Invoice", payment.InvoiceID);
            return View(payment);
        }

        // GET: Payment/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Payment payment = _context.Payment.Single(m => m.ID == id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewData["CreditCardDetailsID"] = new SelectList(_context.CreditCardDetails, "ID", "CreditCardDetails", payment.CreditCardDetailsID);
            ViewData["InvoiceID"] = new SelectList(_context.Invoice, "ID", "Invoice", payment.InvoiceID);
            return View(payment);
        }

        // POST: Payment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Payment payment)
        {
            if (ModelState.IsValid)
            {
                _context.Update(payment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CreditCardDetailsID"] = new SelectList(_context.CreditCardDetails, "ID", "CreditCardDetails", payment.CreditCardDetailsID);
            ViewData["InvoiceID"] = new SelectList(_context.Invoice, "ID", "Invoice", payment.InvoiceID);
            return View(payment);
        }

        // GET: Payment/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Payment payment = _context.Payment.Single(m => m.ID == id);
            if (payment == null)
            {
                return HttpNotFound();
            }

            return View(payment);
        }

        // POST: Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Payment payment = _context.Payment.Single(m => m.ID == id);
            _context.Payment.Remove(payment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
