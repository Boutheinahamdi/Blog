using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;
using System.Collections.Generic;

namespace ProjectAPI.Data
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
            
        }

        public DbSet<Project> projects { get; set; }
    }
}
