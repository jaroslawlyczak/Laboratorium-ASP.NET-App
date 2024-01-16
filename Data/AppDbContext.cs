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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string dbFilePath = Path.Combine(currentDirectory, "database.db3");
        SqliteConnectionStringBuilder builder = new SqliteConnectionStringBuilder();
        builder.DataSource = dbFilePath;
        string connectionString = builder.ConnectionString;
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite(connectionString);
        optionsBuilder.EnableSensitiveDataLogging();
    }

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

        PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
        user.PasswordHash = passwordHasher.HashPassword(user, "1234Abcd$");
        modelBuilder.Entity<IdentityUser>().HasData(user);

        var adminRole = new IdentityRole()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "admin",
            NormalizedName = "ADMIN"
        };
        adminRole.ConcurrencyStamp = adminRole.Id;

        modelBuilder.Entity<IdentityRole>().HasData(adminRole);
        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData
            (
                new IdentityUserRole<string>()
                {
                    RoleId = adminRole.Id,
                    UserId = user.Id,
                }
            );

        modelBuilder.Entity<OrganizationEntity>().HasData
        (
            new OrganizationEntity() { Id = 101, Name = "WSEI", Description = "Uczelnia wyzsza" },
            new OrganizationEntity() { Id = 102, Name = "Comarch", Description = "Przedsiębiorstwo IT" }
        );
        modelBuilder.Entity<ContactEntity>().HasData
        (
            new ContactEntity() { ContactId = 1, Name = "Adam", Email = "adam@wsei.edu.pl", Phone = "124124234", Birth = DateTime.Parse("2000-10-10"), Created = DateTime.Parse("2000-10-10"), Priority = Priority.Low, OrganizationId = 101 },
            new ContactEntity() { ContactId = 2, Name = "John", Email = "john@email.com", Phone = "987654321", Birth = DateTime.Parse("1995-05-15"), Created = DateTime.UtcNow, Priority = Priority.Low, OrganizationId = 101 },
            new ContactEntity() { ContactId = 3, Name = "Alice", Email = "alice@email.com", Phone = "123456789", Birth = DateTime.Parse("1990-08-20"), Created = DateTime.UtcNow, Priority = Priority.Normal, OrganizationId = 102 },
            new ContactEntity() { ContactId = 4, Name = "Bob", Email = "bob@email.com", Phone = "555555555", Birth = DateTime.Parse("1985-11-25"), Created = DateTime.UtcNow, Priority = Priority.Urgent, OrganizationId = 102 }
        );
        modelBuilder.Entity<OrganizationEntity>()
            .OwnsOne(o => o.Adress)
            .HasData
            (
                new { OrganizationEntityId = 101, City = "Krakow", Street = "św. Filipa 17", PostalCode = "31-150" },
                new { OrganizationEntityId = 102, City = "Krakow", Street = "Rozwoju 1/4", PostalCode = "36-160" }
            );


        modelBuilder.Entity<ReservationEntity>().HasData(
            new ReservationEntity()
            {
                ReservationEntityId = 1,
                Data = DateTime.Parse("2000-10-10"),
                Cena = (decimal)190.23,
                ContactEntityContactId = 1,
                ContactName = "Adam"
            },
            new ReservationEntity()
            {
                ReservationEntityId = 2,
                Data = DateTime.Parse("2012-11-11"),
                Cena = (decimal)156.99,
                ContactEntityContactId = 3,
                ContactName = "Alice"
            }
        );

        modelBuilder.Entity<PokojDetailsEntity>().HasData(
            new PokojDetailsEntity()
            {
                Id = 1,
                Nazwa = "Room1",
                Numer = "101",
                Rozmiar = 20,
                Pietro = 1,
            },
            new PokojDetailsEntity()
            {
                Id = 2,
                Nazwa = "Room2",
                Numer = "102",
                Rozmiar = 25,
                Pietro = 2,
            }
        );

        modelBuilder.Entity<ReservationEntity>().OwnsOne(r => r.Adress).HasData(
            new { ReservationEntityId = 1, City = "Krakow", Street = "Mazowiecka 12", PostalCode = "30-015" },
            new { ReservationEntityId = 2, City = "Krakow", Street = "Czarodziejska 2", PostalCode = "30-322" }
            );


    }
}
