using Microsoft.AspNetCore.Identity;


namespace Movies.Models
{
    public class User: IdentityUser<Guid>
    {
        public string? Role { get; set; }
    }
}
