using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class MessageAlertController : Controller
    {
        private ApplicationDbContext _context;

        public MessageAlertController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: MessageAlert
        public IActionResult Index()
        {
            var applicationDbContext = _context.MessageAlert.Include(m => m.CustomerGuest);
            return View(applicationDbContext.ToList());
        }
        // GET: MessageAlert
        public IActionResult IndexToAction()
        {
            var applicationDbContext = _context.MessageAlert.Include(m => m.CustomerGuest).Where(a => a.MessageAlertDelivered.Equals(false));
            return View(applicationDbContext.ToList());
        }

        // GET: MessageAlert/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            MessageAlert messageAlert = _context.MessageAlert.Single(m => m.ID == id);
            if (messageAlert == null)
            {
                return HttpNotFound();
            }

            return View(messageAlert);
        }

        // GET: MessageAlert/Create
        public IActionResult Create()
        {
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerFullName");
            return View();
        }

        // POST: MessageAlert/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MessageAlert messageAlert)
        {
            if (ModelState.IsValid)
            {
                _context.MessageAlert.Add(messageAlert);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerGuest", messageAlert.CustomerGuestID);
            return View(messageAlert);
        }

        // GET: MessageAlert/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            MessageAlert messageAlert = _context.MessageAlert.Single(m => m.ID == id);
            if (messageAlert == null)
            {
                return HttpNotFound();
            }
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerGuest", messageAlert.CustomerGuestID);
            return View(messageAlert);
        }

        // POST: MessageAlert/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MessageAlert messageAlert)
        {
            if (ModelState.IsValid)
            {
                _context.Update(messageAlert);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CustomerGuestID"] = new SelectList(_context.CustomerGuest, "ID", "CustomerGuest", messageAlert.CustomerGuestID);
            return View(messageAlert);
        }

        // GET: MessageAlert/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            MessageAlert messageAlert = _context.MessageAlert.Single(m => m.ID == id);
            if (messageAlert == null)
            {
                return HttpNotFound();
            }

            return View(messageAlert);
        }

        // POST: MessageAlert/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            MessageAlert messageAlert = _context.MessageAlert.Single(m => m.ID == id);
            _context.MessageAlert.Remove(messageAlert);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
