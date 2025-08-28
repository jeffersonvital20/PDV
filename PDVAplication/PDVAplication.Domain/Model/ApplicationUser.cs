using Microsoft.AspNetCore.Identity;

namespace PDVAplication.Domain.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpityTime { get; set; }

    }
}
