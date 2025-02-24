using HotelManagement.Models.Entities;

namespace HotelManagement.Models.Dtos
{
    public class TravelerDto
    {
        public Guid TravelerId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }

    public class TravelerRequestDto
    {
        public string FullName { get; set; }
        public string DocumentType { get; set; }"
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class TravelerResponseDto
    {
        public string FullName { get; set; }
        public string DocumentType { get; set; } 
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

}
