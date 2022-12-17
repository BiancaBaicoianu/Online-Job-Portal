using JobPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Data
{
    // context = parte din entity frame
    public class PortalContext : DbContext  // DbContext = clasa din entity frame
    {
        public DbSet<User> Users { get; set; }  // Users = numele tabelei
        public DbSet<Job> Jobs { get; set; }
        public DbSet<UserApplyingForJob> UsersApplyingForJobs { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<Company> Companies { get; set; }

        public PortalContext(DbContextOptions<PortalContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<UserApplyingForJob>()
                        .HasKey(mr => new { mr.UserId, mr.JobId });
            /*
                     modelBuilder.Entity<UserApplyingForJob>()
                                 .HasOne(mr => mr.Job)
                                 .WithMany(m3 => m3.UsersApplyingForJobs)
                                 .HasForeignKey(mr => mr.JobId);

                     modelBuilder.Entity<UserApplyingForJob>()
                                 .HasOne(mr => mr.User)
                                 .WithMany(m4 => m4.UsersApplyingForJobs)
                                 .HasForeignKey(mr => mr.UserId);

                     // One to Many
                     modelBuilder.Entity<Company>()
                         .HasMany(m1 => m1.Job)
                         .WithOne(m2 => m2.Company);

         */
            // One to One
            modelBuilder.Entity<Job>()
                .HasOne(m5 => m5.JobOffer)
                .WithOne(m6 => m6.Job)
                .HasForeignKey<JobOffer>(m6 => m6.JobForeignKey);
            

            base.OnModelCreating(modelBuilder);
        }
        
    }
        
}




