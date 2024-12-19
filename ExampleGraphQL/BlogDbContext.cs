using CarRentalGraphQL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarRentalGraphQL
{
    public class RentalDbContext : DbContext
    {
        public RentalDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}