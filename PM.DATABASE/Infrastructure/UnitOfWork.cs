using PM.DATABASE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DATABASE.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository userRepository { get; }
        public UnitOfWork(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
    }
}
