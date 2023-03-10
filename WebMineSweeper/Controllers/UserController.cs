using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMineSweeper.Models;

namespace WebMineSweeper.Controllers
{
    public class UserController : Controller
    {
        private readonly minebaseContext _DbContext = new minebaseContext();
        // GET: UserController
        public async Task<IActionResult> Index()
        {
            
            return View(await _DbContext.Users.ToListAsync());
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        } 

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User newUser)
        {
            try
            {
                _DbContext.Users.Add(newUser);
                _DbContext.SaveChanges();
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User editedUser)
        {
            try
            {
                _DbContext.Users.Update(editedUser);
                _DbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _DbContext.Users.FindAsync(id));
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User deletedUser)
        {
            try
            {
                _DbContext.Users.Remove(deletedUser);
                _DbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
