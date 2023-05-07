using Microsoft.EntityFrameworkCore;
using PM.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DATABASE.Infrastructure
{
    public class MasterDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options)
        {

        }
        public DbSet<UserMaster> UserMaster { get; set; }
    }
}
