using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Movies.Controllers
{
    [Authorize]
    public class MyMoviesController : Controller
    {
        // GET: MyMovies
        
        public ActionResult Index()
        {
            return View();
        }

        // GET: MyMovies/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyMovies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyMovies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MyMovies/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyMovies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MyMovies/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyMovies/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
