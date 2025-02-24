using HotelManagement.Domain.Entities;
using HotelManagement.Models.Entities;

namespace HotelManagement.Models.Dtos
{
    public class ReservationDto
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

    public class ReservationRequestDto
    {
        public Guid HotelId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TotalGuests { get; set; }

        public TravelerRequestDto Traveler { get; set; }
        public EmergencyContactRequestDto EmergencyContact { get; set; }
        public List<GuestsRequestDto> Guests { get; set; } = new List<GuestsRequestDto>();
    }



    public class ReservationResponseDto
    {
        public Guid ReservationId { get; set; }
        public Guid HotelId { get; set; }
        public string HotelName { get; set; }
        public Guid RoomId { get; set; }
        public string RoomType { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TotalGuests { get; set; }
        public EmergencyContactResponseDto EmergencyContact { get; set; }
        public TravelerResponseDto Traveler { get; set; }
        public RoomResponseDto Room { get; set; }
    }

}
