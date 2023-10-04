using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RepositoryLesson.Controllers;
using RepositoryLesson.Interfaces;
using RepositoryLesson.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepositoryLesson.Repositories
{
    public class UsersRepository : GenericRepository<Users> , IUsersRepository
    {
        
        public UsersRepository(ShoppingDbContext context) : base(context)
        {
        }
 
        

        public string GenerateToken(Users user, IOptions<JwtOptions> tokenOption)
        {
            List<Claim> claims = new List<Claim>();
            List<Users> claimUser = Find(a => a.Email == user.Email).ToList();
            claims.Add(new Claim(ClaimTypes.Name, user.Email));
            claims.Add(new Claim(ClaimTypes.Role, claimUser[0].Role));
            JwtSecurityToken token = new JwtSecurityToken(
               issuer: tokenOption.Value.Issuer,
            audience: tokenOption.Value.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(tokenOption.Value.Expiration),
                  signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOption.Value.SecretKey)),
                  SecurityAlgorithms.HmacSha256)
           );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string userToken = tokenHandler.WriteToken(token);
            return userToken;
        }

        public Users Login(Users user)
        {
            var userInDb = _context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if(userInDb != null) 
            {
                return userInDb;
            }
            else
            {
                return null;
            }
        }



        public bool Signup(Users model)
        {
            Users user = new Users()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                Role = "Customer",
            };
            _context.Users.Add(user);
            int result = _context.SaveChanges();

            if (result == 0)
            {
                return false;
                
            }
            else
            {
                return true;
            }
        }

        
    }
}
