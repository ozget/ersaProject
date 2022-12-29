using ErsaProject.Application.Dtos;
using ErsaProject.Domain.Entities.Identity;

namespace ErsaProject.Application.Abstractions
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(int second, AppUser appUser);
        string CreateRefreshToken();
    }
}
