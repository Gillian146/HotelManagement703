using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class MaintenanceController : Controller
    {
        private ApplicationDbContext _context;

        public MaintenanceController(ApplicationDbContext context)
        {
            _context = context;    
        }
        public IActionResult Backup()
        {
            return View();
        }

        // GET: Maintenance
        public IActionResult Index()
        {
            var applicationDbContext = _context.Maintenance.Include(m => m.Room).Include(m => m.Staff);
            return View(applicationDbContext.ToList());
        }

        // GET: Maintenance
        public IActionResult IndexToAction()
        {
            var applicationDbContext = _context.Maintenance.Include(m => m.Room).OrderBy(m=>m.Room.RoomNumber).Where(k=>k.MaintenanceCompleted.Equals(false));
            return View(applicationDbContext.ToList());
        }

        // GET: Maintenance/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Maintenance maintenance = _context.Maintenance.Single(m => m.ID == id);
            if (maintenance == null)
            {
                return HttpNotFound();
            }

            return View(maintenance);
        }

        // GET: Maintenance/Create
        public IActionResult Create()
        {
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "RoomNumber");
            ViewData["StaffID"] = new SelectList(_context.Staff, "ID", "StaffFullName");
            return View();
        }

        // POST: Maintenance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Maintenance maintenance)
        {
            if (ModelState.IsValid)
            {
                _context.Maintenance.Add(maintenance);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Room", maintenance.RoomID);
            ViewData["StaffID"] = new SelectList(_context.Staff, "ID", "Staff", maintenance.StaffID);
            return View(maintenance);
        }

        // GET: Maintenance/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Maintenance maintenance = _context.Maintenance.Single(m => m.ID == id);
            if (maintenance == null)
            {
                return HttpNotFound();
            }
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "RoomNumber");
            ViewData["StaffID"] = new SelectList(_context.Staff, "ID", "StaffFullName");
            //ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Room", maintenance.RoomID);
            //ViewData["StaffID"] = new SelectList(_context.Staff, "ID", "Staff", maintenance.StaffID);
            return View(maintenance);
        }

        // POST: Maintenance/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Maintenance maintenance)
        {
            if (ModelState.IsValid)
            {
                _context.Update(maintenance);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Room", maintenance.RoomID);
            ViewData["StaffID"] = new SelectList(_context.Staff, "ID", "Staff", maintenance.StaffID);
            return View(maintenance);
        }

        // GET: Maintenance/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Maintenance maintenance = _context.Maintenance.Single(m => m.ID == id);
            if (maintenance == null)
            {
                return HttpNotFound();
            }

            return View(maintenance);
        }

        // POST: Maintenance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Maintenance maintenance = _context.Maintenance.Single(m => m.ID == id);
            _context.Maintenance.Remove(maintenance);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
