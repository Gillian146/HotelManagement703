using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class HotelController : Controller
    {
        private ApplicationDbContext _context;

        public HotelController(ApplicationDbContext context)
        {
            _context = context;    
        }
        public IActionResult Backup()
        {
            return View();
        }

        // GET: Hotel
        public IActionResult Index()
        {
            return View(_context.Hotel.ToList());
        }

        // GET: Hotel/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Hotel hotel = _context.Hotel.Single(m => m.ID == id);
            if (hotel == null)
            {
                return HttpNotFound();
            }

            return View(hotel);
        }

        // GET: Hotel/Create
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: Hotel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _context.Hotel.Add(hotel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotel);
        }

        // GET: Hotel/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Hotel hotel = _context.Hotel.Single(m => m.ID == id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: Hotel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _context.Update(hotel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotel);
        }

        // GET: Hotel/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Hotel hotel = _context.Hotel.Single(m => m.ID == id);
            if (hotel == null)
            {
                return HttpNotFound();
            }

            return View(hotel);
        }

        // POST: Hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Hotel hotel = _context.Hotel.Single(m => m.ID == id);
            _context.Hotel.Remove(hotel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
