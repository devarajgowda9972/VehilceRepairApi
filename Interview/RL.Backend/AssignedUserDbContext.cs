using Microsoft.EntityFrameworkCore;
using RL.Backend.NewTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL.Backend
{
    public class AssignedUserDbContext : DbContext
    {
        public AssignedUserDbContext(DbContextOptions<AssignedUserDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProcedureUserAssignment> ProcedureUserAssignments { get; set; }
    }
}
