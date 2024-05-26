using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecondAssignment.Models;

public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Tasks> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder); // Это нужно для настройки сущностей Identity

        builder.Entity<Tasks>()
            .HasKey(t => t.TaskId);

        builder.Entity<IdentityUserLogin<string>>()
            .HasKey(x => new {x.LoginProvider, x.ProviderKey}); // Определение первичного ключа для IdentityUserLogin<string>
    }
}