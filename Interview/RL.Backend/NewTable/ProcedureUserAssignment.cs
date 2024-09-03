using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL.Backend.NewTable
{
    public class ProcedureUserAssignment
    {
        public int Id { get; set; }
        public int ProcedureId { get; set; }
        public  Procedure Procedure { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
