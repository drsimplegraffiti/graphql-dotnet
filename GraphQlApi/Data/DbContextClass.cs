using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQlApi.Enitities;
using Microsoft.EntityFrameworkCore;

namespace GraphQlApi.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        {
            
        }
        public DbSet<ProductDetails> Products { get; set; }
    }
}