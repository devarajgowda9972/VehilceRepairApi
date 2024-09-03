namespace RL.Backend.Models
{
    public class ProcedureUserAssignmentRequest
    {
        public int ProcedureId { get; set; }
        public List<int> UserId { get; set; }
    }
}
