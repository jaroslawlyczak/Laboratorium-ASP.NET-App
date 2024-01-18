using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<OrganizationEntity> Organizations { get; set; }
    public DbSet<ReservationEntity> Reservations { get; set; }
    public DbSet<PokojDetailsEntity> PokojDetails { get; set; }
    private string DbPath { get; set; }
    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "reservation.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var user = new IdentityUser()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "adam",
            NormalizedUserName = "ADAM",
            Email = "adam@wsei.edu.pl",
            NormalizedEmail = "ADAM@WSEI.EDU.PL",
            EmailConfirmed = true,

        };
        var regularUser = new IdentityUser()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "ewa",
            NormalizedUserName = "EWA",
            Email = "ewa@wsei.edu.pl",
            NormalizedEmail = "EWA@WSEI.EDU.PL",
            EmailConfirmed = true,
        };

        PasswordHasher<IdentityUser> passwordHasher1 = new PasswordHasher<IdentityUser>();
        user.PasswordHash = passwordHasher1.HashPassword(user, "1234Abcd$");
        modelBuilder.Entity<IdentityUser>().HasData(user);

        PasswordHasher<IdentityUser> passwordHasher2 = new PasswordHasher<IdentityUser>();
        regularUser.PasswordHash = passwordHasher2.HashPassword(regularUser, "Ewa123!");
        modelBuilder.Entity<IdentityUser>().HasData(regularUser);

        
        var adminRole = new IdentityRole()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "admin",
            NormalizedName = "ADMIN"
        };
        adminRole.ConcurrencyStamp = adminRole.Id;

        var userRole = new IdentityRole()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "user",
            NormalizedName = "USER"
        };

        modelBuilder.Entity<IdentityRole>().HasData(adminRole);
        modelBuilder.Entity<IdentityRole>().HasData(userRole);

        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRole.Id,
                    UserId = user.Id,
                },
                new IdentityUserRole<string>
                {
                    UserId = regularUser.Id,
                    RoleId = userRole.Id
                }
            );
        modelBuilder.Entity<ContactEntity>()
        .HasOne(e => e.Organization)
        .WithMany(o => o.Contacts)
        .HasForeignKey(e => e.OrganizationId);

        modelBuilder.Entity<ReservationEntity>()
            .HasOne(e => e.ContactEntity)
            .WithMany(o => o.Reservations)
            .HasForeignKey(e => e.ContactEntityContactId);



        modelBuilder.Entity<OrganizationEntity>().HasData
        (
            new OrganizationEntity() { Id = 101, Name = "Tech University", Description = "Higher Education Institution" },
            new OrganizationEntity() { Id = 102, Name = "Innovatech", Description = "Technology Solutions Company" },
            new OrganizationEntity() { Id = 103, Name = "SoftServe", Description = "Software Development Company" }
        );
        modelBuilder.Entity<ContactEntity>().HasData
        (
            new ContactEntity() { ContactId = 1, Name = "Eva", Email = "eva@techuniversity.com", Phone = "555123456", Birth = DateTime.Parse("1988-02-20"), Created = DateTime.Parse("2022-03-15"), Priority = Priority.Normal, OrganizationId = 101 },
            new ContactEntity() { ContactId = 2, Name = "Mark", Email = "mark@innovatech.com", Phone = "555654321", Birth = DateTime.Parse("1975-08-30"), Created = DateTime.UtcNow, Priority = Priority.Low, OrganizationId = 102 },
            new ContactEntity() { ContactId = 3, Name = "Julia", Email = "julia@softserve.com", Phone = "555789123", Birth = DateTime.Parse("1992-11-15"), Created = DateTime.UtcNow, Priority = Priority.Urgent, OrganizationId = 103 }
        );
        modelBuilder.Entity<OrganizationEntity>()
            .OwnsOne(e => e.Adress)
            .HasData
            (
                new { OrganizationEntityId = 101, City = "Liberty City", Street = "Freedom St 47", PostalCode = "10001" },
                new { OrganizationEntityId = 102, City = "Liberty City", Street = "Innovation Ave 3", PostalCode = "10002" },
                new { OrganizationEntityId = 103, City = "Liberty City", Street = "Tech Park Rd 21", PostalCode = "10003" }
            );
        modelBuilder.Entity<ReservationEntity>().HasData(
            new ReservationEntity()
            {
                ReservationEntityId = 1,
                Data = DateTime.Parse("2023-05-10"),
                Cena = (decimal)250.50,
                ContactEntityContactId = 1,
                ContactName = "Eva"
            },
            new ReservationEntity()
            {
                ReservationEntityId = 2,
                Data = DateTime.Parse("2023-06-15"),
                Cena = (decimal)300.75,
                ContactEntityContactId = 2,
                ContactName = "Mark"
            }
            );

        modelBuilder.Entity<PokojDetailsEntity>().HasData(
            new PokojDetailsEntity()
            {
                Id = 1,
                Nazwa = "Deluxe Suite",
                Numer = "301",
                Rozmiar = 35,
                Pietro = 3,
            },
            new PokojDetailsEntity()
            {
                Id = 2,
                Nazwa = "Standard Room",
                Numer = "202",
                Rozmiar = 20,
                Pietro = 2,
            }
            );

        modelBuilder.Entity<ReservationEntity>().OwnsOne(r => r.Adress).HasData(
            new { ReservationEntityId = 1, City = "Liberty City", Street = "Central Sq 1", PostalCode = "10004" },
            new { ReservationEntityId = 2, City = "Liberty City", Street = "Main St 99", PostalCode = "10005" }
        );
    }
}