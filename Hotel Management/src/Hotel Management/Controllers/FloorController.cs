using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class FloorController : Controller
    {
        private ApplicationDbContext _context;

        public FloorController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Floor
        public IActionResult Index()
        {
            var applicationDbContext = _context.Floor.Include(f => f.Hotel);
            return View(applicationDbContext.ToList());
        }

        // GET: Floor/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Floor floor = _context.Floor.Single(m => m.ID == id);
            if (floor == null)
            {
                return HttpNotFound();
            }

            return View(floor);
        }

        // GET: Floor/Create
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Set<Hotel>(), "ID", "Hotel");
            return View();
        }

        // POST: Floor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Floor floor)
        {
            if (ModelState.IsValid)
            {
                _context.Floor.Add(floor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["HotelID"] = new SelectList(_context.Set<Hotel>(), "ID", "Hotel", floor.HotelID);
            return View(floor);
        }

        // GET: Floor/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Floor floor = _context.Floor.Single(m => m.ID == id);
            if (floor == null)
            {
                return HttpNotFound();
            }
            ViewData["HotelID"] = new SelectList(_context.Set<Hotel>(), "ID", "Hotel", floor.HotelID);
            return View(floor);
        }

        // POST: Floor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Floor floor)
        {
            if (ModelState.IsValid)
            {
                _context.Update(floor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["HotelID"] = new SelectList(_context.Set<Hotel>(), "ID", "Hotel", floor.HotelID);
            return View(floor);
        }

        // GET: Floor/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Floor floor = _context.Floor.Single(m => m.ID == id);
            if (floor == null)
            {
                return HttpNotFound();
            }

            return View(floor);
        }

        // POST: Floor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Floor floor = _context.Floor.Single(m => m.ID == id);
            _context.Floor.Remove(floor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
