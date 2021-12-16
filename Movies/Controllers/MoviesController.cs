using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Models;


namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MoviesContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public MoviesController(
            MoviesContext context, 
            UserManager<User> userManager,
            SignInManager<User> signInManager
            )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        

        

        // GET: Movies
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            // linq для получения списка жанров
            IQueryable<string> genreQuery = from m in _context.Movie 
                                            orderby m.Genre 
                                            select m.Genre;
            
            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(searchString)) 
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            var movieGenreVM = new MovieGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        
        //public async Task<IActionResult> AddToUserList(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
            
        //    var user = await _userManager.GetUserAsync(HttpContext.User);
        //    var movie = await _context.Movie.FirstOrDefaultAsync(m=> m.Id == id);
        //    var userId = new UsersId { Id = user.Id };
        //    if (movie.UsersId == null) { movie.UsersId = new List<UsersId>()}
            
            
        //    _context.UsersMovie.Add()
            

        //    return Redirect("Index");
        //}

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
  
    }
}
