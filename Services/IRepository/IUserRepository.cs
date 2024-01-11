using DataAccess.DTO;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        
        public Task<object> Login(string email, string password);
        public Task<object> getLoginInfo(string email,string password);
        public string getChangePasswordToken(string email);
        public Task<User> getUserById(int id);
        public string ChangePassword(string email, string newPassword);
        public bool checkEmailExistence(string email);
    }
}
