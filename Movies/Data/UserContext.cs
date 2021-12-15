using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movies.Models;
namespace Movies.Data
{
    public class UserDbContext : IdentityDbContext<User,UserRole, Guid>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            :base(options)
        {
            
        }
    }
}
