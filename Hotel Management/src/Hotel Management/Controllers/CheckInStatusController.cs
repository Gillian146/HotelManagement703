using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class CheckInStatusController : Controller
    {
        private ApplicationDbContext _context;

        public CheckInStatusController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CheckInStatus
        public IActionResult Index()
        {
            return View(_context.CheckInStatus.ToList());
        }

        // GET: CheckInStatus/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CheckInStatus checkInStatus = _context.CheckInStatus.Single(m => m.ID == id);
            if (checkInStatus == null)
            {
                return HttpNotFound();
            }

            return View(checkInStatus);
        }

        // GET: CheckInStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CheckInStatus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CheckInStatus checkInStatus)
        {
            if (ModelState.IsValid)
            {
                _context.CheckInStatus.Add(checkInStatus);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(checkInStatus);
        }

        // GET: CheckInStatus/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CheckInStatus checkInStatus = _context.CheckInStatus.Single(m => m.ID == id);
            if (checkInStatus == null)
            {
                return HttpNotFound();
            }
            return View(checkInStatus);
        }

        // POST: CheckInStatus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CheckInStatus checkInStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Update(checkInStatus);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(checkInStatus);
        }

        // GET: CheckInStatus/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CheckInStatus checkInStatus = _context.CheckInStatus.Single(m => m.ID == id);
            if (checkInStatus == null)
            {
                return HttpNotFound();
            }

            return View(checkInStatus);
        }

        // POST: CheckInStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            CheckInStatus checkInStatus = _context.CheckInStatus.Single(m => m.ID == id);
            _context.CheckInStatus.Remove(checkInStatus);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
