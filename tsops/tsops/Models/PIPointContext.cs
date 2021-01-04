using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tsops.Models
{
    public class PIPointContext : DbContext
    {
        public PIPointContext(DbContextOptions<PIPointContext> options) : base(options)
        {

        }

        public DbSet<PIPoint> PIPoints { get; set; }


    }

}
