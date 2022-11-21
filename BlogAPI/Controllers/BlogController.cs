using BlogAPI.Data;
using BlogAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _Logger;
        private readonly BlogContext _context;

        public BlogController(ILogger<BlogController> logger,BlogContext context)
        {
            _Logger = logger;
            _context = context;

        }
        [HttpGet]
        public async Task< IEnumerable<Blog>> getAllBlogs()

        {
            return await _context.blogs.Find(p => true).ToListAsync();  
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<Blog>> Get(string id)
        {
            var blog = await _context.blogs.Find(x => x.title == id).FirstOrDefaultAsync();

            if (blog is null)
            {
                return NotFound();
            }

            return blog;
        }
    }
}
