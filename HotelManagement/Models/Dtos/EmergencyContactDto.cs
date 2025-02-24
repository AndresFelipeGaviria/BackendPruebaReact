using HotelManagement.Models.Entities;

namespace HotelManagement.Models.Dtos
{
    public class EmergencyContactDto
    {
        public Guid EmergencyContactId { get; set; }
        public Guid TravelerId { get; set; }

        public string FullName { get; set; }
        public string Phone { get; set; }

        public Traveler Traveler { get; set; }
    }

    public class EmergencyContactRequestDto
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
    }

    public class EmergencyContactResponseDto
    {
        public Guid EmergencyContactId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }

    }


}
