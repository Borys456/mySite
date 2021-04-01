using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyStorageSite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyStorageSite
{
    public class StorageContext1 : DbContext
    {
        public StorageContext1(DbContextOptions<StorageContext1> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
