using Domain;

namespace Persistence.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}