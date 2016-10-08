using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class BedTypeController : Controller
    {
        private ApplicationDbContext _context;

        public BedTypeController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: BedType
        public IActionResult Index()
        {
            return View(_context.BedType.ToList());
        }

        // GET: BedType/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BedType bedType = _context.BedType.Single(m => m.ID == id);
            if (bedType == null)
            {
                return HttpNotFound();
            }

            return View(bedType);
        }

        // GET: BedType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BedType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BedType bedType)
        {
            if (ModelState.IsValid)
            {
                _context.BedType.Add(bedType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bedType);
        }

        // GET: BedType/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BedType bedType = _context.BedType.Single(m => m.ID == id);
            if (bedType == null)
            {
                return HttpNotFound();
            }
            return View(bedType);
        }

        // POST: BedType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BedType bedType)
        {
            if (ModelState.IsValid)
            {
                _context.Update(bedType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bedType);
        }

        // GET: BedType/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BedType bedType = _context.BedType.Single(m => m.ID == id);
            if (bedType == null)
            {
                return HttpNotFound();
            }

            return View(bedType);
        }

        // POST: BedType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            BedType bedType = _context.BedType.Single(m => m.ID == id);
            _context.BedType.Remove(bedType);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
