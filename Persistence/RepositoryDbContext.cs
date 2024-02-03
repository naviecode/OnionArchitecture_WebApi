using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public sealed class RepositoryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public RepositoryDbContext(DbContextOptions options) : base(options) { }
    }
}
