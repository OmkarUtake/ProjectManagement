using PM.DATABASE.Infrastructure;
using PM.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DATABASE.Repository
{
    public interface IUserRepository : IRepository<UserMaster>
    {

    }
    public class UserRepository : Repository<UserMaster>, IUserRepository
    {
        public UserRepository(MasterDBContext masterDbContext) : base(masterDbContext)
        {

        }
    }
}
