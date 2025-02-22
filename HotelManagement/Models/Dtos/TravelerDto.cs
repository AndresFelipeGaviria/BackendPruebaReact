namespace HotelManagement.Models.Dtos
{
    public class TravelerDto
    {
        public Guid TravelerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

}
