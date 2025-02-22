using Microsoft.AspNetCore.Identity;

namespace HotelManagement.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(IdentityUser user);
    }
}
