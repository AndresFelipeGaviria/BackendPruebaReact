using HotelManagement.Domain.Entities;
using HotelManagement.Models.Dtos;
using HotelManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] HotelRequestDto hotel)
        {
            var result = await _hotelService.CreateHotelAsync(hotel);
            return Ok(result);
        }

        [HttpPut("{hotelId}")]
        public async Task<IActionResult> UpdateHotel(Guid hotelId, [FromBody] HotelUpdateDto hotelDto)
        {
            try
            {
                await _hotelService.UpdateHotelAsync(hotelId, hotelDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
               
            }
        }

        [HttpGet("with-reservations")]
        public async Task<ActionResult<IEnumerable<HotelWithReservationsDto>>> GetHotelsWithReservations()
        {
            try
            {
                var hotels = await _hotelService.GetHotelsWithReservationsAsync();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
            
        }

        [HttpGet("{hotelId}")]
        public async Task<IActionResult> GetHotelById(Guid hotelId)
        {
            try
            {
                var hotel = await _hotelService.GetHotelByIdAsync(hotelId);
                return Ok(hotel);
            }
            catch (CustomException cus)
            {
                return BadRequest(cus.ToResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
           
        }

        [HttpPut("{hotelId}/toggle-status")]
        public async Task<IActionResult> ToggleHotelStatus(Guid hotelId)
        {
            var result = await _hotelService.ToggleHotelStatusAsync(hotelId);
            return result ? Ok() : NotFound();
        }

        [HttpGet("all")]
        public async Task<ActionResult<HotelResponseDto>> GetAllHotels()
        {
            var hotels = await _hotelService.GetAllHotelsAsync();
            return Ok(hotels);
        }
    }
}
