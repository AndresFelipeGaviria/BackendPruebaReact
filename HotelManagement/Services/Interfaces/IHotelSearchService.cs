using HotelManagement.Domain.Entities;
using HotelManagement.Models.Dtos;
using HotelManagement.Models.Entities;

namespace HotelManagement.Services.Interfaces
{
    public interface IHotelSearchService
    {
        Task<IEnumerable<HotelResponseDto>> SearchHotelsAsync(DateTime? checkIn, DateTime? checkOut, int? guests, string? city);
        Task<List<Room>> GetAvailableRoomsAsync(Guid hotelId, DateTime checkIn, DateTime checkOut);
        Task<ReservationResponseDto> CreateReservationAsync(ReservationRequestDto request);
    }
}
