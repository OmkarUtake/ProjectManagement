using Microsoft.EntityFrameworkCore;
using PM.MODEL;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DATABASE
{
    public class MasterDBContext : DbContext
    {
        public MasterDBContext(DbContextOptions<MasterDBContext> options) : base(options)
        {

        }

        public DbSet<UserMaster> UserMaster { get; set; }
    }
}
