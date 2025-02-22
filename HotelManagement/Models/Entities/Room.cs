using HotelManagement.Domain.Entities;

namespace HotelManagement.Models.Entities
{
    public class Room
    {
        public Guid RoomId { get; set; }
        public Guid HotelId { get; set; }
        public string RoomType { get; set; } // Ejemplo: "Suite", "Doble", "Sencilla"
        public decimal BaseCost { get; set; }
        public decimal Taxes { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string Location { get; set; } // Ejemplo: "Piso 3, Habitación 305"

        public Hotel Hotel { get; set; }
    }

}
