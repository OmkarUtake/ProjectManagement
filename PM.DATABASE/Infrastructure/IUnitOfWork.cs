using PM.DATABASE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DATABASE.Infrastructure
{
   public interface IUnitOfWork
    {
       public IUserRepository userRepository { get; }
    }
}
