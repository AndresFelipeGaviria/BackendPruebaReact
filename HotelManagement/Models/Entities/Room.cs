using HotelManagement.Domain.Entities;

namespace HotelManagement.Models.Entities
{
    public class Room
    {
        public Guid RoomId { get; set; }
        public Guid HotelId { get; set; }
        public string RoomType { get; set; } 
        public decimal BaseCost { get; set; }
        public decimal Taxes { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string Location { get; set; } 
        public int Capacity { get; set; } 

        public Hotel Hotel { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }

}
