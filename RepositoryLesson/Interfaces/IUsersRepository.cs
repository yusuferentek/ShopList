using Microsoft.Extensions.Options;
using RepositoryLesson.Controllers;
using RepositoryLesson.Models;

namespace RepositoryLesson.Interfaces
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Users Login(Users user);
        bool Signup(Users user);
        string GenerateToken(Users user, IOptions<JwtOptions> tokenOption);
    }
}
