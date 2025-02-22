namespace HotelManagement.Models.Dtos
{
    public class ReservationDto
    {
        public Guid ReservationId { get; set; }
        public string HotelName { get; set; }
        public string RoomType { get; set; }
        public string TravelerName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int Guests { get; set; }
        public string Status { get; set; }
    }

}
