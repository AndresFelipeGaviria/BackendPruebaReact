using HotelManagement.Domain.Entities;

namespace HotelManagement.Models.Entities
{
    public class Reservation
    {
        public Guid ReservationId { get; set; }
        public Guid HotelId { get; set; }
        public Guid RoomId { get; set; }
        public Guid TravelerId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int Guests { get; set; }
        public string Status { get; set; } = "Pending"; // Ejemplo: "Pending", "Confirmed", "Cancelled"

        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
        public Traveler Traveler { get; set; }
    }

}
