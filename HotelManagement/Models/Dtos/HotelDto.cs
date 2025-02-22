namespace HotelManagement.Models.Dtos
{
    public class HotelDto
    {
        public Guid HotelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }

}
