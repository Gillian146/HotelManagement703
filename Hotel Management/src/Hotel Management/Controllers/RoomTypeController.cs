using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class RoomTypeController : Controller
    {
        private ApplicationDbContext _context;

        public RoomTypeController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: RoomType
        public IActionResult Index()
        {
            return View(_context.RoomType.ToList());
        }

        // GET: RoomType/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            RoomType roomType = _context.RoomType.Single(m => m.ID == id);
            if (roomType == null)
            {
                return HttpNotFound();
            }

            return View(roomType);
        }

        // GET: RoomType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoomType roomType)
        {
            if (ModelState.IsValid)
            {
                _context.RoomType.Add(roomType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roomType);
        }

        // GET: RoomType/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            RoomType roomType = _context.RoomType.Single(m => m.ID == id);
            if (roomType == null)
            {
                return HttpNotFound();
            }
            return View(roomType);
        }

        // POST: RoomType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RoomType roomType)
        {
            if (ModelState.IsValid)
            {
                _context.Update(roomType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roomType);
        }

        // GET: RoomType/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            RoomType roomType = _context.RoomType.Single(m => m.ID == id);
            if (roomType == null)
            {
                return HttpNotFound();
            }

            return View(roomType);
        }

        // POST: RoomType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            RoomType roomType = _context.RoomType.Single(m => m.ID == id);
            _context.RoomType.Remove(roomType);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
