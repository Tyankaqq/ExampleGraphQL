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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-VBHFI92; Initial Catalog=ExampleGraphQL; TrustServerCertificate=Yes; Integrated Security=True");
    }

}