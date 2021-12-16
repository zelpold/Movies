using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Models;
using System.Security.Claims;

namespace Movies.Controllers
{
    public class AdminController : Controller
    {


        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private Claim managerClaim = new Claim(ClaimTypes.Role, "Manager");


        public AdminController(
            UserManager<User> userManager,
            SignInManager<User> signInManager
            )
        {
 
            _userManager = userManager;
            _signInManager = signInManager;
        }




        // GET: Movies
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            
            var users = from u in _userManager.Users
                         select u;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.UserName.Contains(searchString));
            }

            return View(await users.ToListAsync());
        }
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(user); 

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddPolicy(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.AddClaimAsync(user, managerClaim);
            user.Role = "Manager";
            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> RemovePolicy(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.RemoveClaimAsync(user, managerClaim);
            user.Role = null;
            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Index));
        }


    }
}
