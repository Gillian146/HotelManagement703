using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class AgencyController : Controller
    {
        private ApplicationDbContext _context;

        public AgencyController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Agency
        public IActionResult Index()
        {
            return View(_context.Agency.ToList());
        }

        // GET: Agency/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Agency agency = _context.Agency.Single(m => m.ID == id);
            if (agency == null)
            {
                return HttpNotFound();
            }

            return View(agency);
        }

        // GET: Agency/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agency/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Agency agency)
        {
            if (ModelState.IsValid)
            {
                _context.Agency.Add(agency);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agency);
        }

        // GET: Agency/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Agency agency = _context.Agency.Single(m => m.ID == id);
            if (agency == null)
            {
                return HttpNotFound();
            }
            return View(agency);
        }

        // POST: Agency/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Agency agency)
        {
            if (ModelState.IsValid)
            {
                _context.Update(agency);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agency);
        }

        // GET: Agency/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Agency agency = _context.Agency.Single(m => m.ID == id);
            if (agency == null)
            {
                return HttpNotFound();
            }

            return View(agency);
        }

        // POST: Agency/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Agency agency = _context.Agency.Single(m => m.ID == id);
            _context.Agency.Remove(agency);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
