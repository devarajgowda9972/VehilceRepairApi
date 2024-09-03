using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RL.Backend.Models;
using RL.Backend.NewTable;
using System.Data.Entity;


namespace RL.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureUserAssignmentController : ControllerBase
    {
        private readonly AssignedUserDbContext _assignedUserDbContext;

        public ProcedureUserAssignmentController(AssignedUserDbContext assignedUserDbContext)
        {
            _assignedUserDbContext = assignedUserDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AssignUsersToProcedure([FromBody] ProcedureUserAssignmentRequest request)
        {
            // Ensure procedure and users exist
            var procedure = await _assignedUserDbContext.Procedures.FindAsync(request.ProcedureId);
            if (procedure == null) return NotFound();

            var users = await _assignedUserDbContext.Users.Where(u => request.UserId.Contains(u.UserId)).ToListAsync();
            if (users.Count != request.UserId.Count)
            {
                return BadRequest("Some users are invalid");
            }

            // Remove existing assignments
            var existingAssignments = _assignedUserDbContext.ProcedureUserAssignments
                .Where(assignment => assignment.ProcedureId == request.ProcedureId)
                .ToList();
            _assignedUserDbContext.ProcedureUserAssignments.RemoveRange(existingAssignments);

            // Add new assignments
            var assignments = request.UserId.Select(userId => new ProcedureUserAssignment
            {
                ProcedureId = request.ProcedureId,
                UserId = userId
            }).ToList();
            _assignedUserDbContext.ProcedureUserAssignments.AddRange(assignments);

            await _assignedUserDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
