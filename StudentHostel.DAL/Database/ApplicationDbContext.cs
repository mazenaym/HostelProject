
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentHostel.DAL.Entites;

namespace StudentHostel.DAL.Database
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Apartment> apartments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Apartment>()
        .HasOne(a => a.Owner)
        .WithMany() 
        .HasForeignKey(a => a.OwnerId)
        .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Apartment>()
                .HasOne(a => a.Student)
                .WithMany()
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Comment>()
        .HasOne(c => c.Apartment)
        .WithMany(a => a.Comments) 
        .HasForeignKey(c => c.Apartment_Id)
        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
         .HasOne(c => c.Student)
         .WithMany()
         .HasForeignKey(c => c.StudentId)
         .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppUser>()
                .Property(u => u.UserType)
                .IsRequired();
            //modelBuilder.Entity<AppUser>()
            //    .Property(u => u.Id)
            //    .IsRequired();


        }
    }
}