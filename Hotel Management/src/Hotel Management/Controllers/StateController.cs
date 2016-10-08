using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class StateController : Controller
    {
        private ApplicationDbContext _context;

        public StateController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: State
        public IActionResult Index()
        {
            return View(_context.State.ToList());
        }

        // GET: State/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            State state = _context.State.Single(m => m.ID == id);
            if (state == null)
            {
                return HttpNotFound();
            }

            return View(state);
        }

        // GET: State/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: State/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(State state)
        {
            if (ModelState.IsValid)
            {
                _context.State.Add(state);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(state);
        }

        // GET: State/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            State state = _context.State.Single(m => m.ID == id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        // POST: State/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(State state)
        {
            if (ModelState.IsValid)
            {
                _context.Update(state);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(state);
        }

        // GET: State/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            State state = _context.State.Single(m => m.ID == id);
            if (state == null)
            {
                return HttpNotFound();
            }

            return View(state);
        }

        // POST: State/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            State state = _context.State.Single(m => m.ID == id);
            _context.State.Remove(state);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
