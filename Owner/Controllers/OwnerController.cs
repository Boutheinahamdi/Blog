using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Owner.Data;
using Owner.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Owner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly ILogger<OwnerController> _Logger;
        private readonly OwnerContext _context;

        public OwnerController(ILogger<OwnerController> logger, OwnerContext context)
        {
            _Logger = logger;
            _context = context;

        }
        [HttpGet]
        public async Task<IEnumerable<Owner1>> getAllBlogs()

        {
            return await _context.owner.Find(p => true).ToListAsync();
        }
    }
}
