using HotelManagement.Domain.Entities;
using HotelManagement.Models.Dtos;

namespace HotelManagement.Services.Interfaces
{
    public interface IHotelService
    {
        Task<Hotel> CreateHotelAsync(HotelRequestDto hotel);
        Task UpdateHotelAsync(Guid hotelId, HotelUpdateDto hotel);
        Task<bool> ToggleHotelStatusAsync(Guid hotelId);
        Task<IEnumerable<HotelResponseDto>> GetAllHotelsAsync();
        Task<HotelResponseDto?> GetHotelByIdAsync(Guid hotelId);
        Task<List<HotelWithReservationsDto>> GetHotelsWithReservationsAsync();
    }
}
