namespace HotelManagement.Models.Dtos
{
    public class RoomDto
    {
        public Guid RoomId { get; set; }
        public string RoomType { get; set; }
        public decimal BaseCost { get; set; }
        public decimal Taxes { get; set; }
        public bool IsAvailable { get; set; }
        public string Location { get; set; }
    }

}
