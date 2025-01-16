using Domain.Core.App.Cars.Entity;
using Domain.Core.App.Opperators.Entity;
using Domain.Core.App.Requests.Entity;

using Domain.Core.App.Users.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataBase
{
    public class AppDBContext : DbContext
    {
        //public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-03R7JG5\\SQLEXPRESS; Database=HW-20;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Request>().ToTable("Requests");

            modelBuilder.Entity<RequestLog>().ToTable("RequestLogs");
        }


        public DbSet<Car> Cars { get; set; }
        public DbSet<Domain.Core.App.Users.Entity.User> Users { get; set; }
        public DbSet<UserCar> UserCars { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestLog> requestLogs{ get; set; }
    }
}
