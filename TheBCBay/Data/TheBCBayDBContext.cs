using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBCBay.Models;

namespace TheBCBay.Data
{
    public class TheBCBayDBContext : DbContext
    {
        public TheBCBayDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ItemModel> Items { get; set; }
    }
}
