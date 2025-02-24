using HotelManagement.Models.Dtos;
using HotelManagement.Models.Entities;

namespace HotelManagement.Services.Interfaces
{
    public interface IRoomService
    {
        Task<RoomResponseDto> AddRoomToHotelAsync(Guid hotelId, RoomRequestDto room);
        Task UpdateRoomAsync(Guid roomId, RoomUpdateDto room);
        Task<bool> ToggleRoomAvailabilityAsync(Guid roomId);
    }
}
