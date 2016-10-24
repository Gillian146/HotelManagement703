using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class BedToRoomController : Controller
    {
        private ApplicationDbContext _context;

        public BedToRoomController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: BedToRoom
        public IActionResult Index()
        {
            var applicationDbContext = _context.BedToRoom.Include(b => b.BedType).Include(b => b.RoomType);
            return View(applicationDbContext.ToList());
        }

        // GET: BedToRoom/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BedToRoom bedToRoom = _context.BedToRoom.Single(m => m.ID == id);
            if (bedToRoom == null)
            {
                return HttpNotFound();
            }

            return View(bedToRoom);
        }

        // GET: BedToRoom/Create
        public IActionResult Create()
        {
            ViewData["BedTypeID"] = new SelectList(_context.BedType, "ID", "BedTypeName");
            ViewData["RoomTypeID"] = new SelectList(_context.RoomType, "ID", "RoomTypeName");
            return View();
        }

        // POST: BedToRoom/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BedToRoom bedToRoom)
        {
            if (ModelState.IsValid)
            {
                _context.BedToRoom.Add(bedToRoom);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["BedTypeID"] = new SelectList(_context.BedType, "ID", "BedType", bedToRoom.BedTypeID);
            ViewData["RoomTypeID"] = new SelectList(_context.RoomType, "ID", "RoomType", bedToRoom.RoomTypeID);
            return View(bedToRoom);
        }

        // GET: BedToRoom/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BedToRoom bedToRoom = _context.BedToRoom.Single(m => m.ID == id);
            if (bedToRoom == null)
            {
                return HttpNotFound();
            }
            ViewData["BedTypeID"] = new SelectList(_context.BedType, "ID", "BedType", bedToRoom.BedTypeID);
            ViewData["RoomTypeID"] = new SelectList(_context.RoomType, "ID", "RoomType", bedToRoom.RoomTypeID);
            return View(bedToRoom);
        }

        // POST: BedToRoom/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BedToRoom bedToRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Update(bedToRoom);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["BedTypeID"] = new SelectList(_context.BedType, "ID", "BedType", bedToRoom.BedTypeID);
            ViewData["RoomTypeID"] = new SelectList(_context.RoomType, "ID", "RoomType", bedToRoom.RoomTypeID);
            return View(bedToRoom);
        }

        // GET: BedToRoom/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BedToRoom bedToRoom = _context.BedToRoom.Single(m => m.ID == id);
            if (bedToRoom == null)
            {
                return HttpNotFound();
            }

            return View(bedToRoom);
        }

        // POST: BedToRoom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            BedToRoom bedToRoom = _context.BedToRoom.Single(m => m.ID == id);
            _context.BedToRoom.Remove(bedToRoom);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
