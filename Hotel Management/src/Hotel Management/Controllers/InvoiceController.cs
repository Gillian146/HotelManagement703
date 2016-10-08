using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class InvoiceController : Controller
    {
        private ApplicationDbContext _context;

        public InvoiceController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Invoice
        public IActionResult Index()
        {
            return View(_context.Invoice.ToList());
        }

        // GET: Invoice/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Invoice invoice = _context.Invoice.Single(m => m.ID == id);
            if (invoice == null)
            {
                return HttpNotFound();
            }

            return View(invoice);
        }

        // GET: Invoice/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Invoice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Invoice.Add(invoice);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invoice);
        }

        // GET: Invoice/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Invoice invoice = _context.Invoice.Single(m => m.ID == id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoice/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Update(invoice);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invoice);
        }

        // GET: Invoice/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Invoice invoice = _context.Invoice.Single(m => m.ID == id);
            if (invoice == null)
            {
                return HttpNotFound();
            }

            return View(invoice);
        }

        // POST: Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = _context.Invoice.Single(m => m.ID == id);
            _context.Invoice.Remove(invoice);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
