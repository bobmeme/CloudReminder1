using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace web.Data
{
    public class CloudContext : IdentityDbContext<User>
    {
        public CloudContext (DbContextOptions<CloudContext> options)
            : base(options)
        {
        }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Ringtone> Ringtones { get; set; }  
        public DbSet<GroupUser> GroupUsers { get; set; }  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Group>().ToTable("Group");
            modelBuilder.Entity<Group>().HasKey(x => x.ID);
            modelBuilder.Entity<Group>().HasMany(s => s.Events).WithOne(a => a.Group);
            modelBuilder.Entity<Group>().HasMany(s => s.Messages).WithOne(a => a.Group);

            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Event>().HasKey(x => x.ID);
            modelBuilder.Entity<Event>().HasOne(gu => gu.Ringtone)
            .WithMany(c => c.Events);
            //modelBuilder.Entity<Event>().HasOne(a => a.Group).WithMany(s => s.Events);
            //modelBuilder.Entity<Event>().HasOne(a => a.Ringtone).WithMany(s => s.Events);


            modelBuilder.Entity<GroupUser>().ToTable("GroupUser");
            modelBuilder.Entity<GroupUser>().HasKey(x => new { x.GroupId, x.UserId });
            modelBuilder.Entity<GroupUser>().HasOne(gu => gu.Group)
            .WithMany(c => c.GroupUsers)
            .HasForeignKey(x => x.GroupId);
            modelBuilder.Entity<GroupUser>().HasOne(gu => gu.User)
            .WithMany(c => c.GroupUsers)
            .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Message>().ToTable("Message");
            modelBuilder.Entity<Message>().HasKey(x => x.ID);

            modelBuilder.Entity<Ringtone>().ToTable("Ringtone");
            modelBuilder.Entity<Ringtone>().HasKey(x => x.ID);       

            modelBuilder.Entity<User>().ToTable("User");
            

        }
    }
}