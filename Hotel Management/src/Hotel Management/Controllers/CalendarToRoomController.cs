using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class CalendarToRoomController : Controller
    {
        private ApplicationDbContext _context;

        public CalendarToRoomController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CalendarToRoom
        public IActionResult Index()
        {
            var applicationDbContext = _context.CalendarToRoom.Include(c => c.Booking).Include(c => c.Room);
            return View(applicationDbContext.ToList());
        }

        // GET: CalendarToRoom/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CalendarToRoom calendarToRoom = _context.CalendarToRoom.Single(m => m.ID == id);
            if (calendarToRoom == null)
            {
                return HttpNotFound();
            }

            return View(calendarToRoom);
        }

        // GET: CalendarToRoom/Create
        public IActionResult Create()
        {
            ViewData["BookingID"] = new SelectList(_context.Booking.OrderByDescending(b=>b.ID), "ID", "BookingRange");
           
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "RoomNumber");
            return View();
        }

        // POST: CalendarToRoom/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CalendarToRoom calendarToRoom)
        {
            if (ModelState.IsValid)
            {
                _context.CalendarToRoom.Add(calendarToRoom);
                _context.SaveChanges();
                return RedirectToAction("Create");
            }
            ViewData["BookingID"] = new SelectList(_context.Booking, "ID", "Booking", calendarToRoom.BookingID);
            
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Room", calendarToRoom.RoomID);
            return View(calendarToRoom);
        }

        // GET: CalendarToRoom/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CalendarToRoom calendarToRoom = _context.CalendarToRoom.Single(m => m.ID == id);
            if (calendarToRoom == null)
            {
                return HttpNotFound();
            }
            ViewData["BookingID"] = new SelectList(_context.Booking, "ID", "Booking", calendarToRoom.BookingID);
           
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Room", calendarToRoom.RoomID);
            return View(calendarToRoom);
        }

        // POST: CalendarToRoom/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CalendarToRoom calendarToRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Update(calendarToRoom);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["BookingID"] = new SelectList(_context.Booking, "ID", "Booking", calendarToRoom.BookingID);
         
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Room", calendarToRoom.RoomID);
            return View(calendarToRoom);
        }

        // GET: CalendarToRoom/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CalendarToRoom calendarToRoom = _context.CalendarToRoom.Single(m => m.ID == id);
            if (calendarToRoom == null)
            {
                return HttpNotFound();
            }

            return View(calendarToRoom);
        }

        // POST: CalendarToRoom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            CalendarToRoom calendarToRoom = _context.CalendarToRoom.Single(m => m.ID == id);
            _context.CalendarToRoom.Remove(calendarToRoom);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
