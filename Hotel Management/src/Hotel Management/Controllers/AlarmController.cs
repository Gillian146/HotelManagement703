using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;
using System;

namespace Hotel_Management.Controllers
{
    public class AlarmController : Controller
    {
        private ApplicationDbContext _context;

        public AlarmController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Alarm
        public IActionResult Index()
        {
            ///has undelievered at the top
            var applicationDbContext = _context.Alarm.Include(a => a.CustomerGuest).OrderBy(u =>u.AlarmDelivered).ThenBy(d=>d.AlarmDate);
            return View(applicationDbContext.ToList());
        }

        // GET: Alarm
        public IActionResult IndexToAction()
        {
            ///has undelievered at the top
            var applicationDbContext = _context.Alarm.Include(a => a.CustomerGuest).OrderBy(u => u.AlarmDelivered).ThenBy(d => d.AlarmDate)
                .Where(a=>a.AlarmDelivered.Equals(false) && a.AlarmDate == (DateTime.Today));
            return View(applicationDbContext.ToList());
        }

        // GET: Alarm/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Alarm alarm = _context.Alarm.Single(m => m.ID == id);
            if (alarm == null)
            {
                return HttpNotFound();
            }

            return View(alarm);
        }

        // GET: Alarm/Create
        public IActionResult Create()
        {
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerFullName");
            return View();
        }

        // POST: Alarm/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Alarm alarm)
        {
            if (ModelState.IsValid)
            {
                _context.Alarm.Add(alarm);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CustomerGuestID"] = new SelectList(_context.Set<CustomerGuest>(), "ID", "CustomerGuest", alarm.CustomerGuestID);
            return View(alarm);
        }

        // GET: Alarm/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            //include Customers so we can access their fullname, not just ID
            Alarm alarm = _context.Alarm.Include(a => a.CustomerGuest).Single(m => m.ID == id);
            if (alarm == null)
            {
                return HttpNotFound();
            }
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerFullName");
            return View(alarm);
        }

        // POST: Alarm/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Alarm alarm)
        {
            if (ModelState.IsValid)
            {
                _context.Update(alarm);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CustomerGuestID"] = new SelectList(_context.Set<CustomerGuest>(), "ID", "CustomerGuest", alarm.CustomerGuestID);
            return View(alarm);
        }

        // GET: Alarm/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Alarm alarm = _context.Alarm.Single(m => m.ID == id);
            if (alarm == null)
            {
                return HttpNotFound();
            }

            return View(alarm);
        }

        // POST: Alarm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Alarm alarm = _context.Alarm.Single(m => m.ID == id);
            _context.Alarm.Remove(alarm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
