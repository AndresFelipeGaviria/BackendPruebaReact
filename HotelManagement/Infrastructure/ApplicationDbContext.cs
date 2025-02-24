using HotelManagement.Domain.Entities;
using HotelManagement.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Traveler> Travelers { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 📌 Configuración de la relación Hotel - Room (Un hotel tiene muchas habitaciones)
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId);

            // 📌 Configuración de la relación Hotel - Reservation (Un hotel tiene muchas reservas)
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Reservations)
                .HasForeignKey(r => r.HotelId);

            // 📌 Configuración de la relación Room - Reservation (Una habitación puede estar reservada en distintas fechas)
            modelBuilder.Entity<Room>()
                .HasMany(r => r.Reservations) // ✅ Se agrega la navegación en Room
                .WithOne(res => res.Room)
                .HasForeignKey(res => res.RoomId);

            // 📌 Configuración de la relación Traveler - Reservation (Un viajero puede hacer varias reservas)
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Traveler)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.TravelerId);

            // 📌 Configuración de la relación Reservation - Guests (Una reserva puede tener varios huéspedes)
            modelBuilder.Entity<Guest>()
                .HasOne(g => g.Reservation)
                .WithMany(r => r.Guests)
                .HasForeignKey(g => g.ReservationId);

            // 📌 Configuración de la relación Traveler - EmergencyContact (Un viajero tiene un contacto de emergencia)
            modelBuilder.Entity<Traveler>()
                .HasOne(t => t.EmergencyContact)
                .WithOne(ec => ec.Traveler)
                .HasForeignKey<EmergencyContact>(ec => ec.TravelerId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
