using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace acme_backend
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

        public DbSet<Models.Question> Questions { get; set; }

        public DbSet<acme_backend.Models.Project>Project { get; set; }
    }
}
