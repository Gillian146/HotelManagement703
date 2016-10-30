using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;
using System;

namespace Hotel_Management.Controllers
{
    public class BookingController : Controller
    {
        private ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;    
        }

        public IActionResult Tasks()
        {
            return View();
        }
        public IActionResult Reports()
        {
            return View();
        }

        public IActionResult Printed()
        {
            return View();
        }
        // GET: Booking
        public IActionResult Index()
        {
            var applicationDbContext = _context.Booking.Include(b => b.CheckInStatus).Include(b => b.CreditCardDetails).Include(b => b.CustomerGuest).Include(b => b.Invoice).Include(b => b.CalendarToRoom).Include(b => b.RoomType).OrderBy(j=>j.ArrivalDate);
            return View(applicationDbContext.ToList());
        }
        // GET: Booking
        public IActionResult IndexToClean()
        {
            var applicationDbContext = _context.Booking.Include(b => b.CheckInStatus).Include(b => b.CustomerGuest)
                .Include(b => b.CalendarToRoom).Include(b => b.RoomType).Where(l => l.DepartureDate == (DateTime.Today));
            return View(applicationDbContext.ToList());
        }
        // GET: Booking
        public IActionResult IndexToService()
        {
            var applicationDbContext = _context.Booking.Include(b => b.CheckInStatus).Include(b => b.CustomerGuest)
                .Include(b => b.CalendarToRoom).Include(b => b.RoomType).Where(k => k.ArrivalDate < (DateTime.Today) && k.DepartureDate > (DateTime.Today));
            return View(applicationDbContext.ToList());
        }
        // GET: Booking
        public IActionResult IndexFuture()
        {
            var applicationDbContext = _context.Booking.Include(b => b.CheckInStatus)
                .Include(b => b.CreditCardDetails).Include(b => b.CustomerGuest).Include(b => b.Invoice)
                .Include(b => b.CalendarToRoom).Include(b => b.RoomType).OrderBy(j => j.ArrivalDate).Where(b => b.ArrivalDate >= (DateTime.Today) || b.DepartureDate >= (DateTime.Today));
            return View(applicationDbContext.ToList());
        }
        // GET: Booking
        public IActionResult Checkin()
        {
            
            var applicationDbContext = _context.Booking.Include(b => b.CheckInStatus).Include(b => b.CreditCardDetails)
                .Include(b => b.CustomerGuest).Include(b => b.Invoice).Include(b => b.CalendarToRoom)
                .Include(b => b.RoomType).Where(b=>b.ArrivalDate==(DateTime.Today)).Where(k=>k.CheckInStatus==null);
            return View(applicationDbContext.ToList());
        }
        // GET: Booking
        public IActionResult Checkout()
        {

            var applicationDbContext = _context.Booking.Include(b => b.CheckInStatus).Include(b => b.CreditCardDetails)
                .Include(b => b.CustomerGuest).Include(b => b.Invoice).Include(b => b.CalendarToRoom)
                .Include(b => b.RoomType).Where(b => b.DepartureDate == (DateTime.Today)).Where(k => k.CheckInStatus == null || k.CheckInStatus.GuestStatusinRoom == "Checked In");
            return View(applicationDbContext.ToList());
        }

        // GET: Booking/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Booking booking = _context.Booking.Single(m => m.ID == id);
            if (booking == null)
            {
                return HttpNotFound();
            }

            return View(booking);
        }

        // GET: Booking/Create
        public IActionResult Create()
        {
            ViewData["CheckInStatusID"] = new SelectList(_context.Set<CheckInStatus>(), "ID", "CheckInStatus");
            ViewData["CreditCardDetailsID"] = new SelectList(_context.CreditCardDetails, "ID", "CreditCardDetails");
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerFullName");
            ViewData["CalendarToRoomID"] = new SelectList(_context.CalendarToRoom, "ID", "IsBooked");
            ViewData["RoomTypeID"] = new SelectList(_context.RoomType, "ID", "RoomTypeName");
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Booking.Add(booking);
                _context.SaveChanges();
                return RedirectToAction( "Index", "Booking");
            }
            ViewData["CheckInStatusID"] = new SelectList(_context.Set<CheckInStatus>(), "ID", "CheckInStatus", booking.CheckInStatusID);
            ViewData["CreditCardDetailsID"] = new SelectList(_context.CreditCardDetails, "ID", "CreditCardDetails", booking.CreditCardDetailsID);
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerGuest", booking.CustomerGuestID);
            ViewData["InvoiceID"] = new SelectList(_context.Invoice, "ID", "Invoice", booking.InvoiceID);
            return View(booking);
        }

        // GET: Booking/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Booking booking = _context.Booking.Single(m => m.ID == id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewData["CheckInStatusID"] = new SelectList(_context.CheckInStatus, "ID", "GuestStatusatReception");
            ViewData["CreditCardDetailsID"] = new SelectList(_context.CreditCardDetails, "ID", "CreditCardDetails");
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerFullName");
            ViewData["CalendarToRoomID"] = new SelectList(_context.CalendarToRoom, "ID", "IsBooked");
            ViewData["RoomTypeID"] = new SelectList(_context.RoomType, "ID", "RoomTypeName");
            return View(booking);
        }

        // POST: Booking/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Update(booking);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CheckInStatusID"] = new SelectList(_context.Set<CheckInStatus>(), "ID", "CheckInStatus", booking.CheckInStatusID);
            ViewData["CreditCardDetailsID"] = new SelectList(_context.CreditCardDetails, "ID", "CreditCardDetails", booking.CreditCardDetailsID);
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerGuest", booking.CustomerGuestID);
            ViewData["InvoiceID"] = new SelectList(_context.Invoice, "ID", "Invoice", booking.InvoiceID);
            return View(booking);
        }
        // GET: Booking/Edit/5
        public IActionResult EditCheckIn(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Booking booking = _context.Booking.Single(m => m.ID == id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewData["CheckInStatusID"] = new SelectList(_context.CheckInStatus, "ID", "GuestStatusatReception");
            ViewData["CreditCardDetailsID"] = new SelectList(_context.CreditCardDetails, "ID", "CreditCardDetails");
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerFullName");
            ViewData["CalendarToRoomID"] = new SelectList(_context.CalendarToRoom, "ID", "IsBooked");
            ViewData["RoomTypeID"] = new SelectList(_context.RoomType, "ID", "RoomTypeName");
            return View(booking);
        }

        // POST: Booking/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCheckIn(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Update(booking);
                _context.SaveChanges();
                return RedirectToAction("Create", "BedToRoom");
            }
            ViewData["CheckInStatusID"] = new SelectList(_context.Set<CheckInStatus>(), "ID", "CheckInStatus", booking.CheckInStatusID);
            ViewData["CreditCardDetailsID"] = new SelectList(_context.CreditCardDetails, "ID", "CreditCardDetails", booking.CreditCardDetailsID);
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerGuest", booking.CustomerGuestID);
            ViewData["InvoiceID"] = new SelectList(_context.Invoice, "ID", "Invoice", booking.InvoiceID);
            return View(booking);
        }
        // GET: Booking/Edit/5
        public IActionResult EditCheckout(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Booking booking = _context.Booking.Single(m => m.ID == id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewData["CheckInStatusID"] = new SelectList(_context.CheckInStatus, "ID", "GuestStatusatReception");
            ViewData["CreditCardDetailsID"] = new SelectList(_context.CreditCardDetails, "ID", "CreditCardDetails");
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerFullName");
            ViewData["CalendarToRoomID"] = new SelectList(_context.CalendarToRoom, "ID", "IsBooked");
            ViewData["RoomTypeID"] = new SelectList(_context.RoomType, "ID", "RoomTypeName");
            return View(booking);
        }

        // POST: Booking/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCheckout(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Update(booking);
                _context.SaveChanges();
                return RedirectToAction("Checkout");
            }
            ViewData["CheckInStatusID"] = new SelectList(_context.Set<CheckInStatus>(), "ID", "CheckInStatus", booking.CheckInStatusID);
            ViewData["CreditCardDetailsID"] = new SelectList(_context.CreditCardDetails, "ID", "CreditCardDetails", booking.CreditCardDetailsID);
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerGuest", booking.CustomerGuestID);
            ViewData["InvoiceID"] = new SelectList(_context.Invoice, "ID", "Invoice", booking.InvoiceID);
            return View(booking);
        }

        // GET: Booking/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Booking booking = _context.Booking.Single(m => m.ID == id);
            if (booking == null)
            {
                return HttpNotFound();
            }

            return View(booking);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Booking booking = _context.Booking.Single(m => m.ID == id);
            _context.Booking.Remove(booking);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
