namespace HotelManagement.Models.Entities
{
    public class EmergencyContact
    {
        public Guid EmergencyContactId { get; set; }
        public Guid TravelerId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public Traveler Traveler { get; set; }
    }

}
