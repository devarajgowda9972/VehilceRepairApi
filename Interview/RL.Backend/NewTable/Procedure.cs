using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL.Backend.NewTable
{
    public class Procedure
    {
        public int ProcedureId { get; set; }
        public string ProcedureTitle { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
