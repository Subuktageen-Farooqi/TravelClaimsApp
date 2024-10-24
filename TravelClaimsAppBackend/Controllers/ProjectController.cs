using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelClaimsAppBackend.Data;
using TravelClaimsAppBackend.Models;

namespace TravelClaimsAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly TravelClaimsDbContext _context;
        public ProjectController(TravelClaimsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetProjects")]
        public async Task<ActionResult<List<Project>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        [HttpPost]
        [Route("AddProject")]
        public async Task<ActionResult<Project>> AddProject(Project newProject)
        {
            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProjects", newProject);
        }

        [HttpPut]
        [Route("UpdateProject")]
        public async Task<IActionResult> UpdateProject(int id, Project project)
        {
            if (id != project.ProjectId)
            {
                return BadRequest();
            }
            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteProject")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
