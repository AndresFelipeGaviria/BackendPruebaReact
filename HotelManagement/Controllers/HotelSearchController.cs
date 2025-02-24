using HotelManagement.Models.Dtos;
using HotelManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    [Route("api/hotel-search")]
    [ApiController]
    public class HotelSearchController : ControllerBase
    {
        private readonly IHotelSearchService _hotelSearchService;

        public HotelSearchController(IHotelSearchService hotelSearchService)
        {
            _hotelSearchService = hotelSearchService;
        }

        // 🔎 Endpoint para buscar hoteles con filtros
        [HttpGet("search")]
        public async Task<IActionResult> SearchHotels(
            [FromQuery] DateTime? checkIn,
            [FromQuery] DateTime? checkOut,
            [FromQuery] int? guests,
            [FromQuery] string? city
)
        {
            var hotels = await _hotelSearchService.SearchHotelsAsync(checkIn, checkOut, guests, city);
            return Ok(hotels);
        }

        // 🏨 Endpoint para obtener habitaciones disponibles en un hotel
        [HttpGet("hotel/{hotelId}/available-rooms")]
        public async Task<IActionResult> GetAvailableRooms(Guid hotelId, [FromQuery] DateTime checkIn, [FromQuery] DateTime checkOut)
        {
            var rooms = await _hotelSearchService.GetAvailableRoomsAsync(hotelId, checkIn, checkOut);
            return Ok(rooms);
        }

        // ✍️ Endpoint para realizar una reserva
        [HttpPost("reserve")]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationRequestDto request)
        {
            var reservation = await _hotelSearchService.CreateReservationAsync(request);
            return CreatedAtAction(nameof(CreateReservation), new { id = reservation.ReservationId }, reservation);
        }
    }
}
