using AutoMapper;
using DataAccess.Data;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services.IRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public UserRepository(ApiContext context,IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<object> Login(string email,string password)
        {
            User userFound = _context.user.Include(user => user.role).Where(user => user.Email == email).FirstOrDefault();

            SecurityToken token = null;
            var tokenHandler = new JwtSecurityTokenHandler();

            if (userFound != null)
            {
                string result = string.Empty;
                byte[] encryted = System.Text.Encoding.Unicode.GetBytes(password);
                result = Convert.ToBase64String(encryted);
                if (userFound.Password == result)
                {
                    var tokenKey = Encoding.UTF8.GetBytes("the secret key that is going to be used"); //IConfiguration["JWT:Key"]
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                      {
                       new Claim(ClaimTypes.Name, userFound.UserName),
                       new Claim(ClaimTypes.Role,userFound.role.Name.ToString())
                      }),
                        Expires = DateTime.UtcNow.AddMinutes(10),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                    };
                    token = tokenHandler.CreateToken(tokenDescriptor);
                    return tokenHandler.WriteToken(token);
                }
                else
                {
                    return "Wrong password";
                }

            }
            else
            {
                return "User not found";
            }

        }

        public async Task<object> getLoginInfo(string email,string password)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(password);
            result = Convert.ToBase64String(encryted);

            User user = _context.user.Include(u=>u.role)
                .Include(user => user.costumer).ThenInclude(c => c.costumersContacts)
                .Include(u=>u.employee)
                .Where(user => user.Email == email && user.Password == result)
                .FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public string getChangePasswordToken(string email) { 
            User user = _context.user.Where(u => u.Email == email).FirstOrDefault();
            SecurityToken token = null;

            var tokenHandler = new JwtSecurityTokenHandler();
            if (user != null)
            {
                var tokenKey = Encoding.UTF8.GetBytes("the secret key that is going to be used"); //IConfiguration["JWT:Key"]
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                  {
                       new Claim(ClaimTypes.Name, user.UserName),
                       new Claim(ClaimTypes.Role,"Restore")
                  }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            else {
                return null;
            }
        }

        public Task<User> getUserById(int id) {
            User user = _context.user.Include(u => u.role)
                .Include(user => user.costumer).ThenInclude(c => c.costumersContacts)
                .Include(u => u.employee)
                .Where(user => user.Id == id)
                .FirstOrDefault();
            if (user != null)
            {
                return Task.FromResult(user);
            }
            else {
                return null;
            }
        }

        public string ChangePassword(string email, string newPassword) {
            User user = _context.user.Where(u =>u.Email == email).FirstOrDefault();
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(newPassword);
            result = Convert.ToBase64String(encryted);
            user.Password = result;
            _context.SaveChanges();
            
            return email;
        }

        public bool checkEmailExistence(string email) {
            var foundUser = _context.user.FirstOrDefault(user => user.Email == email);
            if (foundUser == null)
            {
                return true;
            }
            else { 
                return false; 
            }

        }

    }


}
