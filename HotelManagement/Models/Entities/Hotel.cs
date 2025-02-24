using HotelManagement.Models.Entities;

namespace HotelManagement.Domain.Entities
{
    public class Hotel
    {
        public Guid HotelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; } = true;
        public string City { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }

}
