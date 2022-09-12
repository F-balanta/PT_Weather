using Persistence;

namespace Application.Interfaces
{
    public interface ITokenGenerator
    {
        string CreateToken(ApplicationUser user);
    }
}
