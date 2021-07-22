using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseApi.Models
{
    public class WarehouseContext: DbContext
    {

        public WarehouseContext(DbContextOptions<WarehouseContext> options)
      : base(options)
        {

        }
        public DbSet<Makes> Makes { get; set; }

        public DbSet<Models> Models { get; set; }
    }
}
