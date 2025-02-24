using HotelManagement.Models.Entities;

namespace HotelManagement.Models.Dtos
{
    public class HotelDto
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

    public class HotelRequestDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
        //public List<RoomRequestDto> Rooms { get; set; }
    }

    public class HotelUpdateDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string City { get; set; }
        public bool? IsActive { get; set; }
    }

    public class HotelResponseDto
    {
        public Guid HotelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string City { get; set; }
        public List<RoomResponseDto> Rooms { get; set; }
    }

    public class HotelWithReservationsDto
    {
        public Guid HotelId { get; set; }
        public string Name { get; set; }
        public List<ReservationResponseDto> Reservations { get; set; }
    }
}
