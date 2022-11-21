using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using ProjectAPII.Data;
using ProjectAPII.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private readonly ILogger<ProjectController> _Logger;
        private readonly ProjectContext _context;

        public ProjectController(ILogger<ProjectController> logger, ProjectContext context)
        {
            _Logger = logger;
            _context = context;

        }
        [HttpGet]
        public async Task<IEnumerable<Project>> getAllBlogs()

        {
            return await _context.projects.Find(p => true).ToListAsync();
        }
        [HttpGet("{title}")]

        public async Task<ActionResult<Project>> Get(string title)
        {
            var project = await _context.projects.Find(x => x.title == title).FirstOrDefaultAsync();

            if (project is null)
            {
                return NotFound();
            }

            return project;
        }
    }
}
