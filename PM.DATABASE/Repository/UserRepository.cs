using PM.DATABASE.Infrastructure;
using PM.MODEL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DATABASE.Repository
{
    public interface IUserRepository : IRepository<UserMaster>
    {
        Task<bool> IsValidUser(string userMail, string password);
        Task<string> GetUserName(string emailId);
    }
    public class UserRepository : Repository<UserMaster>, IUserRepository
    {
        public UserRepository(MasterDBContext masterDbContext) : base(masterDbContext)
        {

        }

        public async Task<string> GetUserName(string emailId)
        {
            var userName = _context.UserMaster.Where(x => x.Email == emailId).Select(x => x.Name).FirstOrDefault();
            return userName;
        }

        public async Task<bool> IsValidUser(string userMail, string password)
        {
            var userExists = _context.UserMaster.Where(x => x.Email == userMail && x.Password == password).Any();
            return userExists;
        }
    }
}
