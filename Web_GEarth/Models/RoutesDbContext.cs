using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_GEarth.Models
{
    public class RoutesDbContext : DbContext
    {
        public RoutesDbContext(DbContextOptions<RoutesDbContext> options) : base(options)
        {

        }

        public DbSet<Route> Routes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
