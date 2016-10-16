using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class CarparkController : Controller
    {
        private ApplicationDbContext _context;

        public CarparkController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Carpark
        public IActionResult Index()
        {
            var applicationDbContext = _context.Carpark.Include(c => c.Hotel);
            return View(applicationDbContext.ToList());
        }

        // GET: Carpark/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Carpark carpark = _context.Carpark.Single(m => m.ID == id);
            if (carpark == null)
            {
                return HttpNotFound();
            }

            return View(carpark);
        }

        // GET: Carpark/Create
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Hotel, "ID", "HotelName");
            return View();
        }

        // POST: Carpark/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Carpark carpark)
        {
            if (ModelState.IsValid)
            {
                _context.Carpark.Add(carpark);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["HotelID"] = new SelectList(_context.Hotel, "ID", "Hotel", carpark.HotelID);
            return View(carpark);
        }

        // GET: Carpark/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Carpark carpark = _context.Carpark.Single(m => m.ID == id);
            if (carpark == null)
            {
                return HttpNotFound();
            }
            ViewData["HotelID"] = new SelectList(_context.Hotel, "ID", "Hotel", carpark.HotelID);
            return View(carpark);
        }

        // POST: Carpark/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Carpark carpark)
        {
            if (ModelState.IsValid)
            {
                _context.Update(carpark);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["HotelID"] = new SelectList(_context.Hotel, "ID", "Hotel", carpark.HotelID);
            return View(carpark);
        }

        // GET: Carpark/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Carpark carpark = _context.Carpark.Single(m => m.ID == id);
            if (carpark == null)
            {
                return HttpNotFound();
            }

            return View(carpark);
        }

        // POST: Carpark/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Carpark carpark = _context.Carpark.Single(m => m.ID == id);
            _context.Carpark.Remove(carpark);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
