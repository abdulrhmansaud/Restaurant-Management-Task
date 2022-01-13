using Microsoft.EntityFrameworkCore;
using Restaurant_Management_Task.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_Management_Task.Data
{
    public class reservationContext : DbContext
    {
        public reservationContext(DbContextOptions<reservationContext> opt) : base(opt)
        {


        }

        public DbSet<User> users { get; set; }
        public DbSet<menuType> menuTypes { get; set; }
        public DbSet<reservation> reservations { get; set; }
    }
}
