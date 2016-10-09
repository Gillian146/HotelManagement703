using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class RoomController : Controller
    {
        private ApplicationDbContext _context;

        public RoomController(ApplicationDbContext context)
        {
            _context = context;    
        }
        public IActionResult Tasks()
        {
            return View();
        }

        // GET: Room
        public IActionResult Index()
        {
            var applicationDbContext = _context.Room.Include(r => r.Floor);
            return View(applicationDbContext.ToList());
        }

        // GET: Room/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Room room = _context.Room.Single(m => m.ID == id);
            if (room == null)
            {
                return HttpNotFound();
            }

            return View(room);
        }

        // GET: Room/Create
        public IActionResult Create()
        {
            ViewData["FloorID"] = new SelectList(_context.Floor, "ID", "FloorName");
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Room.Add(room);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["FloorID"] = new SelectList(_context.Floor, "ID", "Floor", room.FloorID);
            return View(room);
        }

        // GET: Room/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Room room = _context.Room.Single(m => m.ID == id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewData["FloorID"] = new SelectList(_context.Floor, "ID", "Floor", room.FloorID);
            return View(room);
        }

        // POST: Room/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Update(room);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["FloorID"] = new SelectList(_context.Floor, "ID", "Floor", room.FloorID);
            return View(room);
        }

        // GET: Room/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Room room = _context.Room.Single(m => m.ID == id);
            if (room == null)
            {
                return HttpNotFound();
            }

            return View(room);
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Room room = _context.Room.Single(m => m.ID == id);
            _context.Room.Remove(room);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
