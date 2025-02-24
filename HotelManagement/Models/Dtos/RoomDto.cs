using HotelManagement.Domain.Entities;

namespace HotelManagement.Models.Dtos
{
    public class RoomDto
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
    }

    public class RoomRequestDto
    {
        public string RoomType { get; set; }
        public decimal BaseCost { get; set; }
        public decimal Taxes { get; set; }
        public bool IsAvailable { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
    }

    public class RoomResponseDto
    {
        public Guid RoomId { get; set; }
        public string RoomType { get; set; }
        public decimal BaseCost { get; set; }
        public decimal Taxes { get; set; }
        public bool IsAvailable { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
    }

    public class RoomUpdateDto
    {
        public string RoomType { get; set; }
        public decimal BaseCost { get; set; }
        public decimal Taxes { get; set; }
        public bool IsAvailable { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
    }
}
