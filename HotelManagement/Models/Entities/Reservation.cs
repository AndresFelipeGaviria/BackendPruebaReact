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
        public int NumberOfGuests { get; set; }   

        public ICollection<Guest> Guests { get; set; } = new List<Guest>(); 
        public EmergencyContact EmergencyContact { get; set; } 

        public Traveler Traveler { get; set; }
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }

}
