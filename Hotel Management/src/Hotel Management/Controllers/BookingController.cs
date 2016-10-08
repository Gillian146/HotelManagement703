using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

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
        // GET: Booking
        public IActionResult Index()
        {
            var applicationDbContext = _context.Booking.Include(b => b.CreditCardDetails).Include(b => b.CustomerGuest).Include(b => b.Invoice).Include(b => b.Room);
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
            //ViewData["CreditCardDetailsID"] = new SelectList(_context.Set<CreditCardDetails>(), "ID", "CreditCardDetails");
            ViewData["GuestID"] = new SelectList(_context.CustomerGuest.OrderBy(d => d.CustomerLastName), "ID", "CustomerFullName");
           // ViewData["InvoiceID"] = new SelectList(_context.Invoice, "ID", "Invoice");
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "RoomNumber");
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
                return RedirectToAction("Index");
            }
            ViewData["CreditCardDetailsID"] = new SelectList(_context.Set<CreditCardDetails>(), "ID", "CreditCardDetails", booking.CreditCardDetailsID);
            ViewData["CustomerGuestID"] = new SelectList(_context.Set<CustomerGuest>(), "ID", "CustomerGuest", booking.CustomerGuestID);
            ViewData["InvoiceID"] = new SelectList(_context.Set<Invoice>(), "ID", "Invoice", booking.InvoiceID);
            ViewData["RoomID"] = new SelectList(_context.Set<Room>(), "ID", "Room", booking.RoomID);
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
            ViewData["CreditCardDetailsID"] = new SelectList(_context.Set<CreditCardDetails>(), "ID", "CreditCardDetails", booking.CreditCardDetailsID);
            ViewData["CustomerGuestID"] = new SelectList(_context.Set<CustomerGuest>(), "ID", "CustomerGuest", booking.CustomerGuestID);
            ViewData["InvoiceID"] = new SelectList(_context.Set<Invoice>(), "ID", "Invoice", booking.InvoiceID);
            ViewData["RoomID"] = new SelectList(_context.Set<Room>(), "ID", "Room", booking.RoomID);
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
            ViewData["CreditCardDetailsID"] = new SelectList(_context.Set<CreditCardDetails>(), "ID", "CreditCardDetails", booking.CreditCardDetailsID);
            ViewData["CustomerGuestID"] = new SelectList(_context.Set<CustomerGuest>(), "ID", "CustomerGuest", booking.CustomerGuestID);
            ViewData["InvoiceID"] = new SelectList(_context.Set<Invoice>(), "ID", "Invoice", booking.InvoiceID);
            ViewData["RoomID"] = new SelectList(_context.Set<Room>(), "ID", "Room", booking.RoomID);
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
