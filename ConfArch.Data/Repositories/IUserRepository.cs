using ConfArch.Data.Models;

namespace ConfArch.Data.Repositories
{
    public interface IUserRepository
    {
        User GetByUsernameAndPassword(string username, string password);
        User GetByGoogleId(string googleId);
    }
}