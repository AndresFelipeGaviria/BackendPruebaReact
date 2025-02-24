using HotelManagement.Domain.Entities;
using HotelManagement.Models.Dtos;
using HotelManagement.Models.Entities;
using HotelManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost("{hotelId}")]
        public async Task<ActionResult<RoomResponseDto>> AddRoomToHotel(Guid hotelId, [FromBody] RoomRequestDto room)
        {
            try
            {
                var result = await _roomService.AddRoomToHotelAsync(hotelId, room);
                return Ok(result);
            }catch(CustomException ex)
            {
                return BadRequest(ex.ToResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpPut("{roomId}")]
        public async Task<ActionResult> UpdateRoom(Guid roomId, [FromBody] RoomUpdateDto room)
        {
            try
            {
                await _roomService.UpdateRoomAsync(roomId, room);
                return Ok();
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.ToResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

        [HttpPut("rooms/{roomId}/toggle-availability")]
        public async Task<IActionResult> ToggleRoomAvailability(Guid roomId)
        {
            var result = await _roomService.ToggleRoomAvailabilityAsync(roomId);
            return result ? Ok() : NotFound();
        }
    }
}
